//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.IO;
//using MathNet.Numerics.LinearAlgebra;
//using MathNet.Numerics.LinearAlgebra.Double;
//using MathNet.Numerics.Distributions;
//using System.Numerics;

//namespace RadarLib
//{
//	public class Matlab
//	{
//		public static Random random = new Random();

//		public Matrix<double> Yinvert(Matrix<double> Y, int N, int M, double mu)
//		{
//			Matrix<double> Ri = CreateMatrix.DenseIdentity<double>(M, M);

//			Ri = Ri.Divide(mu);

//			for (int i = 0; i < N; i++)
//			{
//				Matrix<double> Ry = (Ri.Multiply(Y.Column(i).ToColumnMatrix()));
//				Console.WriteLine(Ry.ToString());
//				Ri -= (Ry.Multiply(Ry.Transpose()/*REWRITE TRANSPOSITION*/)).Divide(
//					1 + Y.Column(i).ToColumnMatrix().Transpose()/*REWRITE TRANSPOSITION*/.Multiply(Ry)[0, 0]);
//				Console.WriteLine(Ri.ToString());
//			}

//			return Ri;
//		}

//		public Matrix<double> Sinx(Matrix<double> x)
//		{
//			Matrix<double> r = CreateMatrix.DenseOfArray(new double[x.RowCount, x.ColumnCount]);

//			for (int i = 0; i < r.RowCount; i++)
//			{
//				for (int j = 0; j < r.ColumnCount; j++)
//				{
//					r[i, j] = 1;
//				}
//			}

//			for (int i = 0; i < r.RowCount; i++)
//			{
//				for (int j = 0; j < r.ColumnCount; j++)
//				{
//					if (x[i, j] != 0)
//					{
//						r[i, j] = Math.Sin(x[i, j]) / x[i, j];
//					}
//				}
//			}

//			return r;
//		}

//		public double Sinx(double x)
//		{
//			double r = 1;

//			if (x != 0)
//			{
//				r = Math.Sin(x) / x;
//			}

//			return r;
//		}

//		public Matrix<Complex> GetGauss(int M, int N)
//		{
//			int p = 54;
//			double cc = 1.0 / 3;

//			Matrix<double> c1 = CreateMatrix.DenseOfArray(new double[M, N]);
//			Matrix<double> c2 = CreateMatrix.DenseOfArray(new double[M, N]);

//			for (int i = 0; i < c1.RowCount; i++)
//			{
//				for (int j = 0; j < c1.ColumnCount; j++)
//				{
//					for (int q = 0; q < p; q++)
//					{
//						c1[i, j] += random.NextDouble();
//						c2[i, j] += random.NextDouble();
//					}
//				}
//			}

//			//c1 = sum(rand(M, N, p), 3);
//			//c2 = sum(rand(M, N, p), 3);

//			Matrix<Complex> C = CreateMatrix.DenseDiagonal<Complex>(M, N, Complex.Zero);

//			for (int i = 0; i < C.RowCount; i++)
//			{
//				for (int j = 0; j < C.ColumnCount; j++)
//				{
//					C[i, j] += new Complex(cc * (c1[i, j] - p / 2), cc * (c2[i, j] - p / 2));
//				}
//			}

//			return C;
//		}

//		public Vector<Complex> GetPhase(double u, double v, int Mu, int Mv)
//		{
//			List<double> plist = new List<double>();
//			List<double> qlist = new List<double>();

//			for (int i = 0; i < Mv; i++)
//			{
//				for (int j = 0; j < Mu; j++)
//				{
//					plist.Add(j + 1);
//					qlist.Add(i + 1);
//				}
//			}

//			Vector<double> p = CreateVector.DenseOfArray(plist.ToArray());
//			Vector<double> q = CreateVector.DenseOfArray(qlist.ToArray());
//			Vector<double> uv = CreateVector.DenseOfArray(new double[2] { u, v });

//			//F = 2 * j* pi *[p' q'] *[u; v]; WRITE COMPLEX TRANSPOSITION
//			Matrix<double> pq = CreateMatrix.DenseOfColumnVectors(p, q);
//			Console.WriteLine(pq.ToString());

//			Vector<double> Fd = pq.Multiply(uv).Multiply(2 * Math.PI);
//			Vector<Complex> Fc = CreateVector.DenseOfArray(new Complex[Fd.Count]);

//			for (int i = 0; i < Fc.Count; i++)
//			{
//				Fc[i] = new Complex(0, Fd[i]);
//			}

//			return Fc;
//		}

//		public Matrix<Complex> GetPhase(Matrix<double> u, Matrix<double> v, int Mu, int Mv)
//		{
//			List<double> plist = new List<double>();
//			List<double> qlist = new List<double>();

//			for (int i = 0; i < Mv; i++)
//			{
//				for (int j = 0; j < Mu; j++)
//				{
//					plist.Add(j + 1);
//					qlist.Add(i + 1);
//				}
//			}

//			Vector<double> p = CreateVector.DenseOfArray(plist.ToArray());
//			Vector<double> q = CreateVector.DenseOfArray(qlist.ToArray());
//			Matrix<double> uv = CreateMatrix.DenseOfMatrixArray(new Matrix<double>[,] { { u }, { v } });

//			//F = 2 * j* pi *[p' q'] *[u; v]; WRITE COMPLEX TRANSPOSITION
//			Matrix<double> pq = CreateMatrix.DenseOfColumnVectors(p, q);
//			Console.WriteLine(pq.ToString());

//			Matrix<double> Fd = pq.Multiply(uv).Multiply(2 * Math.PI);
//			Matrix<Complex> Fc = CreateMatrix.DenseOfArray(new Complex[Fd.RowCount, Fd.ColumnCount]);

//			for (int i = 0; i < Fc.RowCount; i++)
//			{
//				for (int j = 0; j < Fc.ColumnCount; j++)
//				{

//					Fc[i, j] = new Complex(0, Fd[i, j]);
//				}
//			}

//			return Fc;
//		}

//		//public Matrix<Complex> Exp(Matrix<Complex> b) {

//		//	Matrix<Complex> matrix = CreateMatrix.DenseOfArray(new Complex[b.RowCount, b.ColumnCount]);

//		//	for (int i = 0; i < b.RowCount; i++)
//		//	{
//		//		for (int j = 0; j < b.ColumnCount; j++)
//		//		{
//		//			matrix[i, j] = MathNet.Numerics.ComplexExtensions.Exp(b[i, j]);
//		//		}
//		//	}

//		//	return matrix;
//		//}


//		public Matrix<Complex> Repmat(double block, int rows, int cols)
//		{
//			Complex[,] blocks = new Complex[rows, cols];

//			for (int i = 0; i < rows; i++)
//			{
//				for (int j = 0; j < cols; j++)
//				{
//					blocks[i, j] = new Complex(block, 0);
//				}
//			}

//			return CreateMatrix.DenseOfArray(blocks);
//		}

//		public Matrix<Complex> Repmat(Matrix<Complex> block, int rows, int cols)
//		{
//			Matrix<Complex>[,] matrices = new Matrix<Complex>[rows, cols];

//			for (int i = 0; i < rows; i++)
//			{
//				for (int j = 0; j < cols; j++)
//				{
//					matrices[i, j] = block;
//				}
//			}

//			return CreateMatrix.DenseOfMatrixArray(matrices);
//		}

//		public Matrix<Complex> GetMatrNabl(int N, int Mu, int Mv, double Um, double Vm, double u, double v,
//			double a, double Tc, int Lc, int Kc, Matrix<double> up, Matrix<double> vp, Matrix<double> Ap, double gamma)
//		{ // function Y=getMatrNabl(N,Mu,Mv,Um,Vm,u,v,a,Tc,Lc,Kc,up,vp,Ap,gamma)
//		  //u-(i-1)* du, v-(k-1)* dv,up-(i-1)* du, vp-(k-1)* dv
//		  //u,           v,          up,            vp,

//			int M = Mu * Mv;
//			int Kp = up.ColumnCount;
//			//Nc = u.Length;
//			int Nc = 1;//?

//			double g1 = Sinx(Math.PI * u / Um) * Sinx(Math.PI * v / Vm);
//			Vector<Complex> f1 = GetPhase(u / Um, v / Vm, Mu, Mv);
//			Matrix<Complex> U = CreateVector.DenseOfArray(new Complex[M]).ToRowMatrix();

//			for (int i = 0; i < U.ColumnCount; i++)
//			{
//				U[0, i] = g1;
//			}

//			U = U.PointwiseMultiply(f1.PointwiseExp().ToColumnMatrix());

//			//	[repmat(g1, M, 1).* Exp(f1.ToColumnMatrix())];
//			Matrix<Complex> S = CreateMatrix.DenseDiagonal(N, Nc, Complex.Zero);//zeros(N, Nc);

//			List<int> nlist = new List<int>();
//			for (int i = 1; i < N + 1; i++)
//			{
//				nlist.Add(i);
//			}
//			Vector<int> n = CreateVector.DenseOfArray(nlist.ToArray()); //1:N;
//			bool[] b = new bool[n.Count];

//			for (int l = 0; l < n.Count; l++)
//			{
//				b[l] = n[l] - 1 >= Tc && n[l] - 1 < Tc + Lc;

//				for (int i = 0; i < b.Length; i++)
//				{
//					if (b[i])
//					{

//						List<double> o = new List<double>();
//						o.Add((n[i] - 1 - Tc) / Lc);//o = (n(b) - 1 - Tc(l)) / Lc;
//						Vector<double> ovect = CreateVector.DenseOfEnumerable(o);
//						Vector<Complex> ovect2 = CreateVector.DenseOfArray(new Complex[o.Count]);

//						for (int m = 0; m < ovect2.Count; m++)
//						{
//							ovect2[m] = (ovect[m] * ovect[m] - ovect[m]) * Complex.ImaginaryOne * Math.PI * Kc;
//						}

//						ovect2 = (ovect2).PointwiseExp();


//						S[n[i], l] = ovect2[n[i]];//	S(n(b), l) = exp(-j * pi * Kc * (o.^ 2 - o));
//					}
//				}
//				//end
//			}

//			Matrix<double> g = Sinx(Math.PI * up / Um).PointwiseMultiply(Sinx(Math.PI * vp / Vm));
//			Matrix<Complex> f = GetPhase(up / Um, vp / Vm, Mu, Mv);
//			Matrix<Complex> v1 = Repmat(g.ToComplex(), M, 1).PointwiseMultiply(f.PointwiseExp());
//			Matrix<Complex> v2 = Repmat(g.ToComplex(), M, 1).PointwiseMultiply(f.PointwiseMultiply(f.PointwiseExp()));

//			Matrix<Complex>[,] V = new Matrix<Complex>[1, 2];//[repmat(g, M, 1).* f.PointwiseExp() repmat(g, M, 1).* f.PointwiseMultiply(f.PointwiseExp())];
//			V[0, 0] = v1;
//			V[0, 1] = v2;

//			Matrix<Complex> e1 = Repmat(Ap.ToComplex(), N, 1).PointwiseMultiply(GetGauss(N, Kp));//repmat(Ap, N, 1).* GetGauss(N, Kp)
//			Matrix<Complex> e2 = Repmat(Ap.Multiply(gamma).ToComplex(), N, 1).PointwiseMultiply(GetGauss(N, Kp));//repmat(Ap.* gamma, N, 1).* GetGauss(N, Kp)

//			Matrix<Complex>[,] E = new Matrix<Complex>[1, 2];
//			E[0, 0] = e1;
//			E[0, 1] = e2;

//			Matrix<Complex> mE = CreateMatrix.DenseOfMatrixArray(E);
//			Matrix<Complex> mV = CreateMatrix.DenseOfMatrixArray(V);

//			Matrix<Complex> Y = mV.Multiply(mE.Transpose/*'*/()).Add((U.PointwiseMultiply(Repmat(a, M, 1))).Multiply(S.Transpose())/*'*/).Add(GetGauss(M, N));//TRANSPOSITION

//			return Y;
//		}

//		public void FullMatrNabl(double du, double dv, int N, int Mu, int Mv, double Um, double Vm,
//			double u, double v, double a, double Tc, int ls, int Kc, double[] up, double[] vp, double[] Ap, double gamma)
//		{
//			//clear;
//			//clc;
//			//% function Y = fullMatrNabl(du, dv, N, Mu, Mv, Um, Vm, u, v, a, Tc, Lc, Kc, up, vp, Ap, gamma)
//			//tic;
//			/*int*/
//			N = 128;
//			/*int*/
//			Mu = 8;
//			/*int*/
//			Mv = 8;
//			int M = Mu * Mv; //% ОБЩЕЕ ЧИСЛО МОДУЛЕЙ

//			//% ----------------------------------------------------
//			/*double*/
//			Um = 1.0 / 6;// % ШИРИНА ДН МОДУЛЯ ПО ОДНОЙ ОСИ
//			/*double*/
//			Vm = 1.0 / 6; //% ШИРИНА ДН МОДУЛЯ ПО ДРУГОЙ ОСИ
//			double Up = Um / 8.0; //% ШИРИНА ДН ВСЕЙ РЕШЕТКИ ПО ОДНОЙ ОСИ
//			double Vp = Vm / 8.0; //% ШИРИНА ДН ВСЕЙ РЕШЕТКИ ПО ДРУГОЙ ОСИ
//								  //% -----------------------------------------------------
//			int lu = 6; //% КОЛИЧЕСТВО СЕКТОРОВ ПО ОДНОЙ КООРДИНАТЕ
//			int lv = 6; //% КОЛИЧЕСТВО СЕКТОРОВ ПО ДРУГОЙ КООРДИНАТЕ
//			int lt = 16; //% ОПРЕДЕЛЯЕТСЯ ДАЛЬНОСТЬЮ ПРОСМОТРА
//			/*double*/
//			du = Um; //% СДВИГ ДО ЦЕНТРА СЕКТОРА ПО ОДНОЙ КООРДИНАТЕ
//			/*double*/
//			dv = Vm; //% СДВИГ ДО ЦЕНТРА СЕКТОРА ПО ДРУГОЙ КООРДИНАТЕ
//					 //% --------------------------------------------
//			/*double*/
//			u = 0.0; //% ПОЛОЖЕНИЕ ЦЕЛИ ПО ОДНОЙ КООРДИНАТЕ
//			/*double*/
//			v = 0.0;  //% ПОЛОЖЕНИЕ ЦЕЛИ ПО ДРКГОЙ КООРДИНАТЕ
//			/*double*/
//			a = 0.42; //% МОЩНОСТЬ СИГНАЛА
//			/*double*/
//			Tc = 20; //% НАЧАЛО ПРИХОДА СИГНАЛА


//			/*double[]*/
//			up = new double[2] { 1.5 * Up, -1.5 * Up }; //% ПОЛОЖЕНИЕ ПОМЕХ ПО ОДНОЙ КООРДИНАТЕ
//			/*double[]*/
//			vp = new double[2] { 0.0 * Vp, 0.0 * Vp }; //% ПОЛОЖЕНИЕ ПОМЕХ ПО ДРУГОЙ КООРДИНАТЕ
//			/*double[]*/
//			Ap = new double[2] { 300, 300 };// % МОЩНОСТЬ ПОМЕХ
//			/*double*/
//			gamma = 0;

//			double mu = 3000; //% ПАРАМЕТР МЮ
//			double[] ll;
//			int Ns;
//			bool sig = false;//0; % ТИП СИГНАЛА 0 = импульс 1 = ЛЧМ
//			bool f = true;//1; % ТИП ПРОСМОТРА ПО ВРЕМЕНИ, ТОЛЬКО ДЛЯ ИМПУЛЬСНОГО СИГНАЛА 1 = через ls отсчетов 0 = через 1 отсчет
//			if (sig)
//			//% ---------------------------------------------------
//			{
//				ls = 50;
//				Kc = 50;
//				ll = new double[(N - ls + 1) * 10];// 0:.1:N - ls;
//				ll[0] = 0;

//				for (int i = 1; i < ll.Length; i++)
//				{
//					ll[i] = ll[i - 1] + 0.1;
//				}

//				Ns = ll.Length;
//			}
//			else
//			{
//				Kc = 0;
//				ls = 9;

//				if (f)
//				{
//					// % ДЛИТЕЛЬНОСТЬ СИГНАЛА
//					Ns = N / ls;// % КОЛИЧЕССТВО ПРОВЕРЯЕМЫХ ГИПОТЕЗ ПО ВРЕМЕНИ
//								//ll = 1:ls: N - ls; //% ЗНАЧЕНИЯ НАЧАЛА СИГНАЛА В ГИПОТЕЗАХ

//					ll = new double[(N - ls) / ls];
//					ll[0] = 1;

//					for (int i = 1; i < ll.Length; i++)
//					{
//						ll[i] = ll[i - 1] + ls;
//					}
//				}
//				else
//				{
//					Ns = N - ls;
//					//ll = 1:N - ls;

//					ll = new double[N - ls];

//					for (int i = 1; i < ll.Length + 1; i++)
//					{
//						ll[i] = i;
//					}
//				}
//			}


//			//end
//			//end


//			double U_ = 1 * Up; //% ШАГ РАЗБИВКИ ПРОСТРАНСТВА В ДОЛЯХ ОТ ШИРИНЫ ДН РЕШЕТКИ
//			double[] ii = new double[9]; //0:U_: Um / 2;
//			ii =[-ii(end: -1:2) ii]; //% ЗНАЧЕНИЯ ОДНОГО УГЛА В ГИПОТЕЗАХ
//			int Nu = ii.Length; //% КОЛИЧЕСТВО ПРОВЕРЯЕМЫХ ГИПОТЕЗ ПО ОДНОМУ УГЛУ
//								//% -----------------------------------------------------
//			double V_ = 1 * Vp; //% ШАГ РАЗБИВКИ ПРОСТРАНСТВА В ДОЛЯХ ОТ ШИРИНЫ ДН РЕШЕТКИ
//			double[] kk = new double[9];// 0:V_: Vm / 2;
//			kk =[-kk(end: -1:2) kk]; //% ЗНАЧЕНИЯ ДРУГОГО УГЛА В ГИПОТЕЗАХ


//			int Nv = kk.Length;// % КОЛИЧЕСТВО ПРОВЕРЯЕМЫХ ГИПОТЕЗ ПО ДРУГОМУ УГЛУ

//			//  % --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ -
//			Matrix<Complex> U = CreateMatrix.DenseDiagonal<Complex>(M, Nu * Nv, Complex.Zero);// zeros(M, Nu * Nv);


//[p, q]=ind2sub([Mu Mv],1:M);
//		[i, k]=ind2sub([Nu Nv],1:Nu* Nv);
//%U=Exp(j*2*Math.PI*[p' q']*[ii(i)/Um ; kk(k)/Vm]);
 
			
//		double g = Sinx(Math.PI * ii(i) / Um) * Sinx(Math.PI * kk(k) / Vm);
//		U=Repmat(g, M,1).PointwiseMultiply( Exp(j*2*Math.PI*[p' q']*[ii(i)/Um ; kk(k)/Vm]));
////%---ФОРМИРОВАНИЕ МАССИВА ВЕКТОРОВ ДЛЯ ВСЕХ ГИПОТЕЗ ПО ВРЕМЕНИ---------

//		Matrix<Complex> S = CreateMatrix.DenseDiagonal<Complex>(N, Ns, Complex.Zero);//S=zeros(N, Ns);
//		Metrix<Complex> L = CreateMatrix.DenseDiagonal<Complex>(Nu * Nv, Ns, Complex.Zero);//zeros(Nu* Nv, Ns);


//		List<int> nlist = new List<int>();
//			for (int i = 1; i<N + 1; i++)
//			{
//				nlist.Add(i);
//			}
//	Vector<int> n = CreateVector.DenseOfArray(nlist.ToArray()); //1:N;n=1:N;



//		for(int l = 1; l<Ns+1;l++)//for l=1:Ns
//		{b = n - 1 >= ll(l) & n - 1 < ll(l) + ls;
//		o=(n(b)-1-ll(l))/ls;
//       S(n(b), l)=Math.Exp(-j* Math.PI* Kc*(o.^2-o));
 
//    %S(:, l)=S(:, l)/Math.Sqrt(S(:, l)'*S(:,l));
//S(:, l)=S(:, l)/Math.Sqrt(ls);

//		//end}

	

//		Matrix<double> rU = CreateMatrix.DenseOfArray(new double[U.RowCount, U.ColumnCount]);// real(U);
//		Matrix<double> iU = CreateMatrix.DenseOfArray(new double[U.RowCount, U.ColumnCount]);// imag(U);

//	for (int i = 0; i<U.RowCount; i++)
//			{
//		for (int j = 0; j<U.ColumnCount; j++)
//			{

//		rU[i, j] = U[i, j].Real;
//		iU[i, j] = U[i, j].Imaginary;
//			}
//}

//Matrix<double> rS = CreateMatrix.DenseOfArray(new double[S.RowCount, S.ColumnCount]);// real(S);
//Matrix<double> iS = CreateMatrix.DenseOfArray(new double[S.RowCount, S.ColumnCount]);// imag(S);

//	for (int i = 0; i<S.RowCount; i++)
//			{
//		for (int j = 0; j<S.ColumnCount; j++)
//			{

//		rS[i, j] = S[i, j].Real;
//		iS[i, j] = S[i, j].Imaginary;
//			}
//			}
	
//	File.WriteAllText("../../../Ux.txt",rU);
//	File.WriteAllText("../../../Uy.txt",iU);
//	File.WriteAllText("../../../Sx.txt",rS );
//	File.WriteAllText("../../../Sy.txt",iS);


//Y=zeros(Mu* Mv, N, lu, lv, lt);
//R=zeros(Mu* Mv, Mu* Mv, lu, lv, lt);
//Rinv=zeros(Mu* Mv, Mu* Mv, lu, lv, lt);

//for (int i = 1; i<lu+1; i++)//for i=1:lu
//			{
//	for (int k = 1; k<lv+1; k++)// for k=1:lv
       
//			{
//	for (int l = 1; l<lt+1; l++)// for l=1:lt
//			{
//	//%Y(:,:, i, k)=getMatrNabl(N, Mu, Mv, Um, Vm, u-(i-1)* du, v-(k-1)* dv, a, Tc, Lc, Kc, up-(i-1)* du, vp-(k-1)* dv, Ap, gamma);
//Y(:,:, i, k, l)=GetMatrNabl(N, Mu, Mv, Um, Vm, u-(i-1)* du, v-(k-1)* dv, a, Tc-(l-1)* N, ls, Kc, up+(i-1)* du, vp+(k-1)* dv, Ap, gamma);
//C=Y(:,:, i, k, l);
//R(:,:, i, k, l)=Yinvert(C, N, Mu* Mv, mu);
//			}
//			}
//			}


////end
////end
////end


//rY = real(Y(:,:));
//iY=imag(Y(:,:));


//File.WriteAllText("../../../YX.txt",rY);
//File.WriteAllText("../../../YY.txt",iY);
////%pause;
 
////!matrixTest Yx.txt Yy.txt Rx.txt Ry.txt gRx.txt gRy.txt 576 MAIN PROGRAM

//	 // VISUALIZATION
////load Rx.txt;
////	load Ry.txt;

////	load gRx.txt;
////	load gRy.txt;


////	Rinv=reshape(Rx, M, M, lu, lv, lt)+j* reshape(Ry, M, M, lu, lv, lt);
 
//// for i=1:lu
////    for k=1:lv
////        for l=1:lt
////YS = Y(:,:, i, k, l) * S;
////	RYS=Rinv(:,:, i, k, l)* YS;
////	c1=abs(sum(U'.'.*(Rinv(:,:, i, k, l)* U)).');
////c2=abs(1-sum(YS'.'.*RYS));
////L(:,:, i, k, l)=abs(U'*RYS).^2./(c1*c2);
////L(:,:, i, k, l)=real(L(:,:, i, k, l));
////L(:,:, i, k, l)=mu* L(:,:, i, k, l)./(1-L(:,:, i, k, l)); % ФОРМИРОВАНИЕ ТРЕБУЕМОЙ СТАТИСТИКИ

////				  end

////	end
//// end



////figure(1);
////	H=7;
////%Hm=max(L(:));
////Hm=90;
////%L2=L(:,:,1,1,1);
////	L2=L;
////ind=find(L2>H);
////	v=L2(L2>H);
////	vvv=v;
 
////% [x1, y1, z1]=ind2sub([Nu Nv Ns], ind);
////	[x1, y1, z1, u1, v1, t1]=ind2sub([Nu Nv Ns lu lv lt], ind);
////% x=ii(x1);
////% y=kk(y1);
////% z=ll(z1);


////	x=ii(x1)'+(u1-1)*Um;
////y=kk(y1)'+(v1-1)*Vm;
////z=ll(z1)'+(t1-1)*N;
 
////delete(gca)
////marker='o';
////string=' ';
////miv=H;
////mav=Hm;
////% Get the current colormap


////map=colormap;
 
////hold on
////for i=1:length(x)
////    in=round((v(i)-miv)* (length(map)-1)/(mav-miv));
////    %--- Catch the out-of-range numbers
////    if in==0;in=1;end
////    if in > length(map);in=length(map); end
////	 plot3(x(i), y(i), z(i), marker,'color', map(in,:),'markerfacecolor',map(in,:))
    
////end
////hold off
 
////% Re-format the colorbar
////h = colorbar;

////	set(h,'ylim', [1 length(map)]);
////	yal=linspace(1, length(map),10);
////	set(h,'ytick', yal);
////% Create the yticklabels
////ytl = linspace(miv, mav, 10);
////	s=char (10,4);
////for i=1:10
////    if abs(min(log10(abs(ytl)))) <= 3
////        B=sprintf('%-4.3f', ytl(i));
////    else
////        B=sprintf('%-4.2E', ytl(i));
////	end
////	s(i,1:length(B))=B;
////end
////set(h,'yticklabel', s,'fontsize',9);
////	grid on
////set(get(h,'title'),'string',string,'fontweight','bold')
////view(3)
////%axis([ii(1) ii(end) kk(1) kk(end) ll(1) ll(end)]);
 
////% for i=1:lu* lv
////%     nrmX(i)=norm(Rx(:,64*(i-1) +(1:64))-gRx(:,64*(i-1) +(1:64)));
////%     nrmY(i)=norm(Ry(:,64*(i-1) +(1:64))-gRy(:,64*(i-1) +(1:64)));
////% 
////% end
////% disp([max(nrmX') max(nrmY')]);
////%----------------------------------------------------
//////figure(2);
//////	Rinv=reshape(gRx, M, M, lu, lv, lt)+j* reshape(gRy, M, M, lu, lv, lt);
 
////// for i=1:lu
//////    for k=1:lv
//////        for l=1:lt
//////YS = Y(:,:, i, k, l) * S;
//////	RYS=Rinv(:,:, i, k, l)* YS;
//////	c1=abs(sum(U'.'.*(Rinv(:,:, i, k, l)* U)).');
//////c2=abs(1-sum(YS'.'.*RYS));
//////L(:,:, i, k, l)=abs(U'*RYS).^2./(c1*c2);
//////L(:,:, i, k, l)=real(L(:,:, i, k, l));
//////L(:,:, i, k, l)=mu* L(:,:, i, k, l)./(1-L(:,:, i, k, l)); % ФОРМИРОВАНИЕ ТРЕБУЕМОЙ СТАТИСТИКИ

//////				  end

//////	end
////// end




//////H=7;
//////%Hm=max(L(:));
//////Hm=90;
//////%L2=L(:,:,1,1,1);
//////	L2=L;
//////ind=find(L2>H);
//////	v=L2(L2>H);
 
 
//////% [x1, y1, z1]=ind2sub([Nu Nv Ns], ind);
//////	[x1, y1, z1, u1, v1, t1]=ind2sub([Nu Nv Ns lu lv lt], ind);
//////% x=ii(x1);
//////% y=kk(y1);
//////% z=ll(z1);


//////	x=ii(x1)'+(u1-1)*Um;
//////y=kk(y1)'+(v1-1)*Vm;
//////z=ll(z1)'+(t1-1)*N;
 
//////delete(gca)
//////marker='o';
//////string=' ';
//////miv=H;
//////mav=Hm;
//////% Get the current colormap


//////map=colormap;
 
//////hold on
//////for i=1:length(x)
//////    in=round((v(i)-miv)* (length(map)-1)/(mav-miv));
//////    %--- Catch the out-of-range numbers
//////    if in==0;in=1;end
//////    if in > length(map);in=length(map); end
//////	 plot3(x(i), y(i), z(i), marker,'color', map(in,:),'markerfacecolor',map(in,:))
    
//////end
//////hold off
 
//////% Re-format the colorbar
//////h = colorbar;

//////	set(h,'ylim', [1 length(map)]);
//////	yal=linspace(1, length(map),10);
//////	set(h,'ytick', yal);
//////% Create the yticklabels
//////ytl = linspace(miv, mav, 10);
//////	s=char (10,4);
//////for i=1:10
//////    if abs(min(log10(abs(ytl)))) <= 3
//////        B=sprintf('%-4.3f', ytl(i));
//////    else
//////        B=sprintf('%-4.2E', ytl(i));
//////	end
//////	s(i,1:length(B))=B;
//////end
//////set(h,'yticklabel', s,'fontsize',9);
//////	grid on
//////set(get(h,'title'),'string',string,'fontweight','bold')
//////view(3)

//		}
//	}
//}

