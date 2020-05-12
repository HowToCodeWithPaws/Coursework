function Toc=CreateL(N,Mu,Mv,Um,Vm,mu,expH)
tic;

M = Mu*Mv;
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

ms = VisFiles(3, N,Um,Vm,Nu, Nv, Ns, lu, lv, lt, ii,kk,ll,Lfile,expH, 'Статистика наблюдений', [0 10 400 300]);

Toc = [toc ms];
end