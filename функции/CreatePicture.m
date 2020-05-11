function Toc=CreatePicture(N, Mu, Mv,Um,Vm, expH, filecode)
tic;
M=Mu*Mv;

%hypothetical signals information
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

ms = [0 0];

if filecode == 1
    load Ux.txt;
    load Uy.txt;
    load Sx.txt;
    load Sy.txt;

    S= reshape(Sx,N,Ns)+j*reshape(Sy,N,Ns);
    
    VisFiles(filecode, N,Um,Vm,Nu, Nv, Ns, lu, lv, lt, ii,kk,ll,Ux,expH, 'Вещественные составляющие пробных сигналов по углам', [0 200 500 400]);
    VisFiles(filecode, N,Um,Vm,Nu, Nv, Ns, lu, lv, lt, ii,kk,ll,Uy,expH, 'Комплексные составляющие пробных сигналов по углам', [390 200 500 400]);
    VisFiles(filecode, N,Um,Vm,Nu, Nv, Ns, lu, lv, lt, ii,kk,ll,S,expH, 'Пробные сигналы по времени', [780 200 500 400]);
else
    if filecode==2
        load Rx.txt;
        load Ry.txt;
        
        VisR(N,Um,Vm,Nu, Nv, Ns, lu, lv, lt, ii,kk,ll,Rx,expH, 'Вещественные составляющие обратной корреляционной матрицы', [0 200 500 400]);
        VisR(N,Um,Vm,Nu, Nv, Ns, lu, lv, lt, ii,kk,ll,Ry,expH, 'Комплексные составляющие обратной корреляционной матрицы', [500 200 500 400]);
    else
        if filecode ==3

            load Lfile.txt;
            ms = VisFiles(filecode, N,Um,Vm,Nu, Nv, Ns, lu, lv, lt, ii,kk,ll,Lfile,expH, 'Статистика наблюдений', [0 200 500 400]);
        end
    end
end

Toc=[toc ms];
end