function Toc=VisR(N,Um,Vm,Nu, Nv, Ns, lu, lv, lt,ii,kk,ll, Arr,expH, name, position)
tic;

h1 =figure('Name',name, 'Position', position,'NumberTitle','off');
    figure(h1);
    
axis([-0.1 0.1 -0.1 0.1])

for i=1:100
    
    figure(h1);
    
L = Arr(:, i, :); 

if expH>max(Arr(:))
    H=min(Arr(:));
else
    H= expH;
end

Hm=max(Arr(:));
%Hm=90;
%L2=L(:,:,1,1,1);
L2=L;
ind=find(L2>H);
v=L2(L2>H);

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
string='сигнал';
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
    
axis([-0.1 0.08 -0.1 0.08]);
    plot(x(i),y(i),marker,'color',map(in,:),'markerfacecolor',map(in,:))
    
end
hold off
 
% Re-format the colorbar
h=colorbar;
 
%set(h,'ylim',[1 length(map)]);
yal=linspace(1,length(map),10);
%set(h,'ytick',yal);

% Create the yticklabels
ytl=linspace(miv,mav,11);

s=char(11,4);

for i=1:11
    if abs(min(log10(abs(ytl)))) <= 3
        B=sprintf('%-4.3f',ytl(i));
    else
        B=sprintf('%-4.2E',ytl(i));
    end
    s(i,1:length(B))=B;
end

set(h,'yticklabel',s,'fontsize',9);
grid on
set(get(h,'title'),'string',string)
view;
end
Toc=toc;
end