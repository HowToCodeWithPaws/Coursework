 function Toc=CreateFiles(N,Mu,Mv,Um,Vm,du,dv,u,v,a,Tc,up1,up2,vp1,vp2,Ap1,Ap2,gamma,mu)
tic;

up = [up1 up2];
vp = [vp1 vp2];
Ap = [Ap1 Ap2];

M = Mu*Mv; % ОБЩЕЕ ЧИСЛО МОДУЛЕЙ

arr = essentCounts(N,Um, Vm);
Nu = cell2mat(arr(1));
Nv=cell2mat(arr(2));
Ns=cell2mat(arr(3));
lu = cell2mat(arr(4));
lv = cell2mat(arr(5));
lt  = cell2mat(arr(6));
ii = cell2mat(arr(7));
kk = cell2mat(arr(8));
ll = cell2mat(arr(9));
Kc=cell2mat(arr(10));
ls = cell2mat(arr(11));

%--ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
U=zeros(M,Nu*Nv);
 
[p,q]=ind2sub([Mu Mv],1:M);
[i,k]=ind2sub([Nu Nv],1:Nu*Nv);
%U=exp(j*2*pi*[p' q']*[ii(i)/Um ; kk(k)/Vm]);
 
g=sinx(pi*ii(i)/Um).*sinx(pi*kk(k)/Vm);
U=repmat(g,M,1).*exp(j*2*pi*[p' q']*[ii(i)/Um ; kk(k)/Vm]);

VisFiles(1, N,Um,Vm,Nu, Nv, Ns, lu, lv, lt, ii,kk,ll,imag(U),0, 'Комплексные составляющие пробных сигналов по углам', [0 200 500 400]);
VisFiles(1, N,Um,Vm,Nu, Nv, Ns, lu, lv, lt, ii,kk,ll,real(U),0, 'Вещественные составляющие пробных сигналов по углам', [390 200 500 400]);

rU=real(U);
iU=imag(U);
 
save Ux.txt rU -ascii;
save Uy.txt iU -ascii;

%---ФОРМИРОВАНИЕ МАССИВА ВЕКТОРОВ ДЛЯ ВСЕХ ГИПОТЕЗ ПО ВРЕМЕНИ---------
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
 
VisFiles(1, N,Um,Vm,Nu, Nv, Ns, lu, lv, lt, ii,kk,ll,S,0, 'Пробные сигналы по времени', [780 200 500 400]);
 
rS=real(S);
iS=imag(S);
 
save Sx.txt rS -ascii;
save Sy.txt iS -ascii;
 
Y=zeros(Mu*Mv,N,lu,lv,lt);
R=zeros(Mu*Mv,Mu*Mv,lu,lv,lt);
Rinv=zeros(Mu*Mv,Mu*Mv,lu,lv,lt);
for i=1:lu
    for k=1:lv
        for l=1:lt
Y(:,:,i,k,l)=getMatrNabl(N,Mu,Mv,Um,Vm,u-(i-1)*du,v-(k-1)*dv,a,Tc-(l-1)*N,ls,Kc,up+(i-1)*du,vp+(k-1)*dv,Ap,gamma);
C=Y(:,:,i,k,l);    
R(:,:,i,k,l)=Yinvert(C,N,Mu*Mv,mu);
        end
    end
end

rY=real(Y(:,:));
iY=imag(Y(:,:));

save YX.txt rY -ascii;
save YY.txt iY -ascii;

Toc=toc;
end