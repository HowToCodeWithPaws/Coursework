function r=ssinx()
Nc = 1;
ls = 3;
Mu=2;
Mv=2;
Kc=50;
N = 12;
lu=2; % ÊÎËÈ×ÅÑÒÂÎ ÑÅÊÒÎĞÎÂ ÏÎ ÎÄÍÎÉ ÊÎÎĞÄÈÍÀÒÅ
lv=2; % ÊÎËÈ×ÅÑÒÂÎ ÑÅÊÒÎĞÎÂ ÏÎ ÄĞÓÃÎÉ ÊÎÎĞÄÈÍÀÒÅ
lt=6;

				ls = 9;
                
                 for p=1:lt
Tc=20-(p-1)* N
n=1:N
for l=1:Nc
    nn=n-1;
    tt = Tc(l);
    ts=tt+ls;
    b=nn>=tt&nn<ts
    aaa = n(b)
    o=(aaa-1-tt)/ls
    S(n(b),l)=(o)
end
                 end
r(c)=1;