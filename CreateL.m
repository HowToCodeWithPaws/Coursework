function Toc=CreateL(N,Mu,Mv,Um,Vm,mu)
tic;

M = Mu*Mv;

Up= Um/8; % ШИРИНА ДН ВСЕЙ РЕШЕТКИ ПО ОДНОЙ ОСИ
Vp= Vm/8; % ШИРИНА ДН ВСЕЙ РЕШЕТКИ ПО ДРУГОЙ ОСИ
%-----------------------------------------------------
lu=6; % КОЛИЧЕСТВО СЕКТОРОВ ПО ОДНОЙ КООРДИНАТЕ
lv=6; % КОЛИЧЕСТВО СЕКТОРОВ ПО ДРУГОЙ КООРДИНАТЕ
lt=16; % ОПРЕДЕЛЯЕТСЯ ДАЛЬНОСТЬЮ ПРОСМОТРА

sig=0; % ТИП СИГНАЛА 0=импульс 1=ЛЧМ
f=1; % ТИП ПРОСМОТРА ПО ВРЕМЕНИ, ТОЛЬКО ДЛЯ ИМПУЛЬСНОГО СИГНАЛА 1= через ls отсчетов 0=через 1 отсчет
if sig
%---------------------------------------------------
ls=50;
Kc=50;
ll=0:.1:N-ls;
Ns=length(ll);
else
    Kc=0;
    ls=9;
    
if f
 % ДЛИТЕЛЬНОСТЬ СИГНАЛА
Ns=fix(N/ls); % КОЛИЧЕССТВО ПРОВЕРЯЕМЫХ ГИПОТЕЗ ПО ВРЕМЕНИ
ll=1:ls:N-ls; % ЗНАЧЕНИЯ НАЧАЛА СИГНАЛА В ГИПОТЕЗАХ
else
    Ns=N-ls;
    ll=1:N-ls;
end
end
 
U_=1*Up; % ШАГ РАЗБИВКИ ПРОСТРАНСТВА В ДОЛЯХ ОТ ШИРИНЫ ДН РЕШЕТКИ 
ii=0:U_:Um/2;
ii=[-ii(end:-1:2) ii]; % ЗНАЧЕНИЯ ОДНОГО УГЛА В ГИПОТЕЗАХ
Nu=length(ii); % КОЛИЧЕСТВО ПРОВЕРЯЕМЫХ ГИПОТЕЗ ПО ОДНОМУ УГЛУ
%-----------------------------------------------------
V_=1*Vp; % ШАГ РАЗБИВКИ ПРОСТРАНСТВА В ДОЛЯХ ОТ ШИРИНЫ ДН РЕШЕТКИ 
kk=0:V_:Vm/2;
kk=[-kk(end:-1:2) kk]; % ЗНАЧЕНИЯ ДРУГОГО УГЛА В ГИПОТЕЗАХ
Nv=length(kk); % КОЛИЧЕСТВО ПРОВЕРЯЕМЫХ ГИПОТЕЗ ПО ДРУГОМУ УГЛУ
 
L=zeros(Nu*Nv,Ns);

load Sx.txt;
load Sy.txt;

S= reshape(Sx,N,Ns)+j*reshape(Sy,N,Ns);

load Ux.txt;
load Uy.txt;

U= reshape(Ux,M,Nu*Nv)+j*reshape(Uy,M,Nu*Nv);

load YX.txt;
load YY.txt;

Y= reshape(YX,Mu*Mv,N,lu,lv,lt)+j*reshape(YY,Mu*Mv,N,lu,lv,lt);

load Rx.txt;
load Ry.txt;
 
Rinv=reshape(Rx,M,M,lu,lv,lt)+j*reshape(Ry,M,M,lu,lv,lt);
 
 for i=1:lu
    for k=1:lv
        for l=1:lt
YS=Y(:,:,i,k,l)*S;
RYS=Rinv(:,:,i,k,l)*YS;
c1=abs(sum(U'.'.*(Rinv(:,:,i,k,l)*U)).');
c2=abs(1-sum(YS'.'.*RYS));
L(:,:,i,k,l)=abs(U'*RYS).^2./(c1*c2);
L(:,:,i,k,l)=real(L(:,:,i,k,l));
L(:,:,i,k,l)=mu*L(:,:,i,k,l)./(1-L(:,:,i,k,l)); % ФОРМИРОВАНИЕ ТРЕБУЕМОЙ СТАТИСТИКИ
        end
    end
 end
 
Lfile=L(:,:);
save Lfile.txt Lfile -ascii;

Toc = toc;
end