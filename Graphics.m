clear;
clc;
%function Y=fullMatrNabl(du,dv,N,Mu,Mv,Um,Vm,u,v,a,Tc,Lc,Kc,up,vp,Ap,gamma)
tic;

input = importdata("C:\Users\Natalya\Desktop\Coursework\Coursework\bin\Debug\Input.txt");

N =input(1);
Mu = input(2);
Mv = input(3);
Um=input(4);
Vm=input(5);
du = input(6);
dv = input(7);
u=input(8);
v=input(9);
a=input(10);
Tc=input(11);
up1=input(12);
up2=input(13);
vp1=input(14);
vp2=input(15);
Ap1=input(16);
Ap2=input(17);
gamma=input(18);
mu = input(19);

M = Mu*Mv; % ÎÁÙÅÅ ×ÈÑËÎ ÌÎÄÓËÅÉ
 
 
%----------------------------------------------------

Up= Um/8; % ØÈÐÈÍÀ ÄÍ ÂÑÅÉ ÐÅØÅÒÊÈ ÏÎ ÎÄÍÎÉ ÎÑÈ
Vp= Vm/8; % ØÈÐÈÍÀ ÄÍ ÂÑÅÉ ÐÅØÅÒÊÈ ÏÎ ÄÐÓÃÎÉ ÎÑÈ
%-----------------------------------------------------
lu=6; % ÊÎËÈ×ÅÑÒÂÎ ÑÅÊÒÎÐÎÂ ÏÎ ÎÄÍÎÉ ÊÎÎÐÄÈÍÀÒÅ
lv=6; % ÊÎËÈ×ÅÑÒÂÎ ÑÅÊÒÎÐÎÂ ÏÎ ÄÐÓÃÎÉ ÊÎÎÐÄÈÍÀÒÅ
lt=16; % ÎÏÐÅÄÅËßÅÒÑß ÄÀËÜÍÎÑÒÜÞ ÏÐÎÑÌÎÒÐÀ

%--------------------------------------------

up=[up1 up2]; % ÏÎËÎÆÅÍÈÅ ÏÎÌÅÕ ÏÎ ÎÄÍÎÉ ÊÎÎÐÄÈÍÀÒÅ
vp=[vp1 vp2]; % ÏÎËÎÆÅÍÈÅ ÏÎÌÅÕ ÏÎ ÄÐÓÃÎÉ ÊÎÎÐÄÈÍÀÒÅ
Ap=[Ap1 Ap2]; % ÌÎÙÍÎÑÒÜ ÏÎÌÅÕ
 

 
 
sig=0; % ÒÈÏ ÑÈÃÍÀËÀ 0=èìïóëüñ 1=Ë×Ì
f=1; % ÒÈÏ ÏÐÎÑÌÎÒÐÀ ÏÎ ÂÐÅÌÅÍÈ, ÒÎËÜÊÎ ÄËß ÈÌÏÓËÜÑÍÎÃÎ ÑÈÃÍÀËÀ 1= ÷åðåç ls îòñ÷åòîâ 0=÷åðåç 1 îòñ÷åò
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
 % ÄËÈÒÅËÜÍÎÑÒÜ ÑÈÃÍÀËÀ
Ns=fix(N/ls); % ÊÎËÈ×ÅÑÑÒÂÎ ÏÐÎÂÅÐßÅÌÛÕ ÃÈÏÎÒÅÇ ÏÎ ÂÐÅÌÅÍÈ
ll=1:ls:N-ls; % ÇÍÀ×ÅÍÈß ÍÀ×ÀËÀ ÑÈÃÍÀËÀ Â ÃÈÏÎÒÅÇÀÕ
else
    Ns=N-ls;
    ll=1:N-ls;
end
end
 
U_=1*Up; % ØÀÃ ÐÀÇÁÈÂÊÈ ÏÐÎÑÒÐÀÍÑÒÂÀ Â ÄÎËßÕ ÎÒ ØÈÐÈÍÛ ÄÍ ÐÅØÅÒÊÈ 
ii=0:U_:Um/2;
ii=[-ii(end:-1:2) ii]; % ÇÍÀ×ÅÍÈß ÎÄÍÎÃÎ ÓÃËÀ Â ÃÈÏÎÒÅÇÀÕ
Nu=length(ii); % ÊÎËÈ×ÅÑÒÂÎ ÏÐÎÂÅÐßÅÌÛÕ ÃÈÏÎÒÅÇ ÏÎ ÎÄÍÎÌÓ ÓÃËÓ
%-----------------------------------------------------
V_=1*Vp; % ØÀÃ ÐÀÇÁÈÂÊÈ ÏÐÎÑÒÐÀÍÑÒÂÀ Â ÄÎËßÕ ÎÒ ØÈÐÈÍÛ ÄÍ ÐÅØÅÒÊÈ 
kk=0:V_:Vm/2;
kk=[-kk(end:-1:2) kk]; % ÇÍÀ×ÅÍÈß ÄÐÓÃÎÃÎ ÓÃËÀ Â ÃÈÏÎÒÅÇÀÕ
 
Nv=length(kk); % ÊÎËÈ×ÅÑÒÂÎ ÏÐÎÂÅÐßÅÌÛÕ ÃÈÏÎÒÅÇ ÏÎ ÄÐÓÃÎÌÓ ÓÃËÓ


load C:\Users\Natalya\Desktop\Coursework\Coursework\bin\Debug\Lfile.txt;
L = Lfile; 

figure(1);
H=input(20);
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
string=' ';
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
 
set(h,'ylim',[1 length(map)]);
yal=linspace(1,length(map),10);
set(h,'ytick',yal);
% Create the yticklabels
ytl=linspace(miv,mav,10);
s=char(10,4);
for i=1:10
    if abs(min(log10(abs(ytl)))) <= 3
        B=sprintf('%-4.3f',ytl(i));
    else
        B=sprintf('%-4.2E',ytl(i));
    end
    s(i,1:length(B))=B;
end
set(h,'yticklabel',s,'fontsize',9);
grid on
set(get(h,'title'),'string',string,'fontweight','bold')
view(3)
%axis([ii(1) ii(end) kk(1) kk(end) ll(1) ll(end)]);
 
% for i=1:lu*lv
%     nrmX(i)=norm(Rx(:,64*(i-1) +(1:64))-gRx(:,64*(i-1) +(1:64)));
%     nrmY(i)=norm(Ry(:,64*(i-1) +(1:64))-gRy(:,64*(i-1) +(1:64)));
% 
% end
% disp([max(nrmX') max(nrmY')]);
%----------------------------------------------------