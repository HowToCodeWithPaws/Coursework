function Y=getMatrNabl(N,Mu,Mv,Um,Vm,u,v,a,Tc,Lc,Kc,up,vp,Ap,gamma)
M=Mu*Mv;
Kp=length(up);
Nc=length(u);
 
g=sinx(pi*u/Um).*sinx(pi*v/Vm);
f=getPhase(u/Um,v/Vm,Mu,Mv);
U=[repmat(g,M,1).*exp(f)];
S=zeros(N,Nc);
n=1:N;
for l=1:Nc
    b=n-1>=Tc(l)&n-1<Tc(l)+Lc;
    o=(n(b)-1-Tc(l))/Lc;
    S(n(b),l)=exp(-j*pi*Kc*(o.^2-o));
end
g=sinx(pi*up/Um).*sinx(pi*vp/Vm);
f=getPhase(up/Um,vp/Vm,Mu,Mv);
V=[repmat(g,M,1).*exp(f) repmat(g,M,1).*f.*exp(f)];
E=[repmat(Ap,N,1).*getGauss(N,Kp), repmat(Ap.*gamma,N,1).*getGauss(N,Kp)]; 
Y=V*E'+(U.*repmat(a,M,1))*S'+getGauss(M,N);
end
