function Toc=VisFiles(filecode, N,Um,Vm,Nu, Nv, Ns, lu, lv, lt,ii,kk,ll, Arr,expH, name, position)
tic;

L = Arr; 

if expH>max(L(:))
    H=min(L(:));
else
    H= expH;
end

figure('Name',name, 'Position', position,'NumberTitle','off');
Hm=max(L(:));
L2=L;
ind=find(L2>H);
v=L2(L2>H);
 
[x1,y1,z1,u1,v1,t1]=ind2sub([Nu Nv Ns lu lv lt],ind);
 
x=ii(x1)'+(u1-1)*Um;
y=kk(y1)'+(v1-1)*Vm;
z=ll(z1)'+(t1-1)*N;
 
delete(gca)
string='сигнал';
miv=H;
mav=Hm;

% Get the current colormap
map=colormap;
 
%plot all the dots
hold on
for i=1:length(x)
    in=round((v(i)-miv)*(length(map)-1)/(mav-miv));
    %--- Catch the out-of-range numbers
    if in==0;in=1;end
    if in > length(map);in=length(map);end
    
    theta = x(i);
    phi = y(i);
    
    X = cos(phi)*cos(theta);
    Y = cos(phi)*sin(theta);
    Z = sin(phi)*ones(size(theta));
       
    if filecode==3 && v(i)>=Hm
         plot3(X,Y,Z, 'p','MarkerSize',15,'MarkerEdgeColor','black', 'color',map(in,:),'markerfacecolor',map(in,:))
    else 
        plot3(X,Y,Z, 'o','MarkerSize',6,'color',map(in,:),'markerfacecolor',map(in,:))
    end
    
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
view(3)
Toc=[min(L(:)) max(L(:))];

end