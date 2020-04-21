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

M = Mu*Mv; % ����� ����� �������
 
 
%----------------------------------------------------

Up= Um/8; % ������ �� ���� ������� �� ����� ���
Vp= Vm/8; % ������ �� ���� ������� �� ������ ���
%-----------------------------------------------------
lu=6; % ���������� �������� �� ����� ����������
lv=6; % ���������� �������� �� ������ ����������
lt=16; % ������������ ���������� ���������

%--------------------------------------------

up=[up1 up2]; % ��������� ����� �� ����� ����������
vp=[vp1 vp2]; % ��������� ����� �� ������ ����������
Ap=[Ap1 Ap2]; % �������� �����
 

 
 
sig=0; % ��� ������� 0=������� 1=���
f=1; % ��� ��������� �� �������, ������ ��� ����������� ������� 1= ����� ls �������� 0=����� 1 ������
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
 % ������������ �������
Ns=fix(N/ls); % ����������� ����������� ������� �� �������
ll=1:ls:N-ls; % �������� ������ ������� � ���������
else
    Ns=N-ls;
    ll=1:N-ls;
end
end
 
U_=1*Up; % ��� �������� ������������ � ����� �� ������ �� ������� 
ii=0:U_:Um/2;
ii=[-ii(end:-1:2) ii]; % �������� ������ ���� � ���������
Nu=length(ii); % ���������� ����������� ������� �� ������ ����
%-----------------------------------------------------
V_=1*Vp; % ��� �������� ������������ � ����� �� ������ �� ������� 
kk=0:V_:Vm/2;
kk=[-kk(end:-1:2) kk]; % �������� ������� ���� � ���������
 
Nv=length(kk); % ���������� ����������� ������� �� ������� ����
 
%--������������ ������� ������� ��������� ������� ��� ���� ������� �� ����-
U=zeros(M,Nu*Nv);
 
[p,q]=ind2sub([Mu Mv],1:M);
[i,k]=ind2sub([Nu Nv],1:Nu*Nv);
%U=exp(j*2*pi*[p' q']*[ii(i)/Um ; kk(k)/Vm]);
 
g=sinx(pi*ii(i)/Um).*sinx(pi*kk(k)/Vm);
U=repmat(g,M,1).*exp(j*2*pi*[p' q']*[ii(i)/Um ; kk(k)/Vm]);
%---������������ ������� �������� ��� ���� ������� �� �������---------
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
 
rU=real(U);
iU=imag(U);
 
rS=real(S);
iS=imag(S);
 
save C:\Users\Natalya\Desktop\Coursework\Coursework\bin\Debug\Ux.txt rU -ascii;
save C:\Users\Natalya\Desktop\Coursework\Coursework\bin\Debug\Uy.txt iU -ascii;
 
save C:\Users\Natalya\Desktop\Coursework\Coursework\bin\Debug\Sx.txt rS -ascii;
save C:\Users\Natalya\Desktop\Coursework\Coursework\bin\Debug\Sy.txt iS -ascii;
 
 
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

rY=real(Y(:,:));
iY=imag(Y(:,:));

save C:\Users\Natalya\Desktop\Coursework\Coursework\bin\Debug\YX.txt rY -ascii;
save C:\Users\Natalya\Desktop\Coursework\Coursework\bin\Debug\YY.txt iY -ascii;