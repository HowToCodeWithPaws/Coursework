function r=sinx(x)
r=ones(size(x));
c=x~=0;
r(c)=sin(x(c))./x(c);