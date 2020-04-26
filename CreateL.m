function Toc=CreateL(N,Mu,Mv,Um,Vm,du,dv,u,v,a,Tc,up1,up2,vp1,vp2,Ap1,Ap2,gamma,mu)
tic;

M = Mu*Mv; % ОБЩЕЕ ЧИСЛО МОДУЛЕЙ
  
%----------------------------------------------------

Up= Um/8; % ШИРИНА ДН ВСЕЙ РЕШЕТКИ ПО ОДНОЙ ОСИ
Vp= Vm/8; % ШИРИНА ДН ВСЕЙ РЕШЕТКИ ПО ДРУГОЙ ОСИ
%-----------------------------------------------------
lu=6; % КОЛИЧЕСТВО СЕКТОРОВ ПО ОДНОЙ КООРДИНАТЕ
lv=6; % КОЛИЧЕСТВО СЕКТОРОВ ПО ДРУГОЙ КООРДИНАТЕ
lt=16; % ОПРЕДЕЛЯЕТСЯ ДАЛЬНОСТЬЮ ПРОСМОТРА

%--------------------------------------------

up=[up1 up2]; % ПОЛОЖЕНИЕ ПОМЕХ ПО ОДНОЙ КООРДИНАТЕ
vp=[vp1 vp2]; % ПОЛОЖЕНИЕ ПОМЕХ ПО ДРУГОЙ КООРДИНАТЕ
Ap=[Ap1 Ap2]; % МОЩНОСТЬ ПОМЕХ
 

 
 
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
 
%--ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
U=zeros(M,Nu*Nv);
 
[p,q]=ind2sub([Mu Mv],1:M);
[i,k]=ind2sub([Nu Nv],1:Nu*Nv);
%U=exp(j*2*pi*[p' q']*[ii(i)/Um ; kk(k)/Vm]);
 
g=sinx(pi*ii(i)/Um).*sinx(pi*kk(k)/Vm);
U=repmat(g,M,1).*exp(j*2*pi*[p' q']*[ii(i)/Um ; kk(k)/Vm]);

S=zeros(N,Ns);
L=zeros(Nu*Nv,Ns);
n=1:N;
for l=1:Ns
    
    b=n-1>=ll(l)&n-1<ll(l)+ls;
    o=(n(b)-1-ll(l))/ls;
       S(n(b),l)=exp(-j*pi*Kc*(o.^2-o));
 
    %S(:,l)=S(:,l)/sqrt(S(:,l)'*S(:,l));
S(:,l)=S(:,l)/sqrt(ls);
 
end

Y=zeros(Mu*Mv,N,lu,lv,lt);
R=zeros(Mu*Mv,Mu*Mv,lu,lv,lt);
Rinv=zeros(Mu*Mv,Mu*Mv,lu,lv,lt);
for i=1:lu
    for k=1:lv
        for l=1:lt
%Y(:,:,i,k)=getMatrNabl(N,Mu,Mv,Um,Vm,u-(i-1)*du,v-(k-1)*dv,a,Tc,Lc,Kc,up-(i-1)*du,vp-(k-1)*dv,Ap,gamma);
Y(:,:,i,k,l)=getMatrNabl(N,Mu,Mv,Um,Vm,u-(i-1)*du,v-(k-1)*dv,a,Tc-(l-1)*N,ls,Kc,up+(i-1)*du,vp+(k-1)*dv,Ap,gamma);
C=Y(:,:,i,k,l);    
R(:,:,i,k,l)=Yinvert(C,N,Mu*Mv,mu);
        end
    end
end

 
load C:\Users\Natalya\Desktop\Coursework\Coursework\bin\x64\Debug\Rx.txt;
load C:\Users\Natalya\Desktop\Coursework\Coursework\bin\x64\Debug\Ry.txt;
 
 
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
save C:\Users\Natalya\Desktop\Coursework\Coursework\bin\x64\Debug\Lfile.txt Lfile -ascii;

Toc = toc;
end