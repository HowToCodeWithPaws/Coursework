function Toc=CreatePicture(N, Mu, Mv,Um,Vm, expH, filecode)
tic;
M=Mu*Mv;
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

ms = 0;

if filecode == 1
    load Ux.txt;
    load Uy.txt;
    load Sx.txt;
    load Sy.txt;

    S= reshape(Sx,N,Ns)+j*reshape(Sy,N,Ns);
    
    VisFiles(N,Um,Vm,Nu, Nv, Ns, lu, lv, lt, ii,kk,ll,Uy,expH, 'Комплексные составляющие пробных сигналов по углам', [0 200 500 400]);
    VisFiles(N,Um,Vm,Nu, Nv, Ns, lu, lv, lt, ii,kk,ll,Ux,expH, 'Вещественные составляющие пробных сигналов по углам', [390 200 500 400]);
    VisFiles(N,Um,Vm,Nu, Nv, Ns, lu, lv, lt, ii,kk,ll,S,expH, 'Пробные сигналы по времени', [780 200 500 400]);
else
    if filecode==2
        load Rx.txt;
        load Ry.txt;
        R=reshape(Rx,M,M,lu,lv,lt)+j*reshape(Ry,M,M,lu,lv,lt);
        VisFiles(N,Um,Vm,Nu, Nv, Ns, lu, lv, lt, ii,kk,ll,R,expH, 'Обратная корреляционная матрица', [390 200 500 400]);
    else
        if filecode ==3

        load Lfile.txt;
        ms = VisFiles(N,Um,Vm,Nu, Nv, Ns, lu, lv, lt, ii,kk,ll,Lfile,expH, 'Статистика наблюдений', [20 50 500 400]);
        end
    end
end

Toc=[toc ms];
end