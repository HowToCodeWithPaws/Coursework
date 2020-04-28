function Toc=CreatePicture(N,Um,Vm, H)
tic;

Up= Um/8; % ШИРИНА ДН ВСЕЙ РЕШЕТКИ ПО ОДНОЙ ОСИ
Vp= Vm/8; % ШИРИНА ДН ВСЕЙ РЕШЕТКИ ПО ДРУГОЙ ОСИ
%-----------------------------------------------------
lu=6; % КОЛИЧЕСТВО СЕКТОРОВ ПО ОДНОЙ КООРДИНАТЕ
lv=6; % КОЛИЧЕСТВО СЕКТОРОВ ПО ДРУГОЙ КООРДИНАТЕ
lt=16; % ОПРЕДЕЛЯЕТСЯ ДАЛЬНОСТЬЮ ПРОСМОТРА
%--------------------------------------------
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

load Lfile.txt;
L = Lfile; 

figure(1);
Hm=max(L(:));
%Hm=90;
%L2=L(:,:,1,1,1);
L2=L;
ind=find(L2>H);
v=L2(L2>H);
vvv=v;
 
% [x1,y1,z1]=ind2sub([Nu Nv Ns],ind);
[x1,y1,z1,u1,v1,t1]=ind2sub([Nu Nv Ns lu lv lt],ind);
% x=ii(x1);
% y=kk(y1);
% z=ll(z1);
 
x=ii(x1)'+(u1-1)*Um;
y=kk(y1)'+(v1-1)*Vm;
z=ll(z1)'+(t1-1)*N;
 
delete(gca)
marker='o';
string='сигнал';
miv=H;
mav=Hm;
% Get the current colormap
map=colormap;
 
hold on
for i=1:length(x)
    in=round((v(i)-miv)*(length(map)-1)/(mav-miv));
    %--- Catch the out-of-range numbers
    if in==0;in=1;end
    if in > length(map);in=length(map);end
    plot3(x(i),y(i),z(i),marker,'color',map(in,:),'markerfacecolor',map(in,:))
    
end
hold off
 
% Re-format the colorbar
h=colorbar;
 
%set(h,'ylim',[1 length(map)]);
yal=linspace(1,length(map),10);
%set(h,'ytick',yal);

% Create the yticklabels
ytl=linspace(miv,mav,11);

s=char(11,4);

for i=1:11
    if abs(min(log10(abs(ytl)))) <= 3
        B=sprintf('%-4.3f',ytl(i));
    else
        B=sprintf('%-4.2E',ytl(i));
    end
    s(i,1:length(B))=B;
end

set(h,'yticklabel',s,'fontsize',9);
grid on
set(get(h,'title'),'string',string)
view(3)

Toc=toc;
end