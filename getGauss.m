function C=getGauss(M,N)
p=54;
cc=1/3;
c1=sum(rand(M,N,p),3);
c2=sum(rand(M,N,p),3);
C=cc*(c1-p/2)+j*cc*(c2-p/2);
end
