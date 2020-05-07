function Ri = Yinvert(Y,N,M,mu);
%M = 6;
%N = 3;
%Y = fix(100*rand(N,M))
 
%include "matrix.h"
%R = mxCreateNumericMatrix(M, N, mxCOMPLEX_CLASS,1);
 
 
%R = mu*eye(N,N) + Y*(Y')
Ri = eye(M,M)./mu;
for j = 1:N
   
    Ry = Ri*Y(:,j);
    Ri = Ri - ( Ry*Ry' )./( 1 + Y(:,j)'*Ry );
end
%Ri
