function Ri = Yinvert(Y,N,M,mu)
%R = mu*eye(N,N) + Y*(Y')
Ri = eye(M,M)./mu;
for j = 1:N
    Ry = Ri*Y(:,j);
    Ri = Ri - ( Ry*Ry' )./( 1 + Y(:,j)'*Ry );
end