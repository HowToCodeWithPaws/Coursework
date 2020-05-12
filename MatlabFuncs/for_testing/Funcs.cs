/*
* MATLAB Compiler: 8.0 (R2020a)
* Date: Tue May 12 20:12:02 2020
* Arguments:
* "-B""macro_default""-W""dotnet:MatlabFuncs,Funcs,4.0,private,version=1.0""-T""link:lib""
* -d""C:\Users\Natalya\Desktop\Coursework\MatlabFuncs\for_testing""-v""class{Funcs:C:\User
* s\Natalya\Desktop\Coursework\�㭪樨\CreateFiles.m,C:\Users\Natalya\Desktop\Coursework\�
* 㭪樨\CreateL.m,C:\Users\Natalya\Desktop\Coursework\�㭪樨\CreatePicture.m}"
*/
using System;
using System.Reflection;
using System.IO;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

#if SHARED
[assembly: System.Reflection.AssemblyKeyFile(@"")]
#endif

namespace MatlabFuncs
{

  /// <summary>
  /// The Funcs class provides a CLS compliant, MWArray interface to the MATLAB functions
  /// contained in the files:
  /// <newpara></newpara>
  /// C:\Users\Natalya\Desktop\Coursework\�������\CreateFiles.m
  /// <newpara></newpara>
  /// C:\Users\Natalya\Desktop\Coursework\�������\CreateL.m
  /// <newpara></newpara>
  /// C:\Users\Natalya\Desktop\Coursework\�������\CreatePicture.m
  /// </summary>
  /// <remarks>
  /// @Version 1.0
  /// </remarks>
  public class Funcs : IDisposable
  {
    #region Constructors

    /// <summary internal= "true">
    /// The static constructor instantiates and initializes the MATLAB Runtime instance.
    /// </summary>
    static Funcs()
    {
      if (MWMCR.MCRAppInitialized)
      {
        try
        {
          Assembly assembly= Assembly.GetExecutingAssembly();

          string ctfFilePath= assembly.Location;

		  int lastDelimiter = ctfFilePath.LastIndexOf(@"/");

	      if (lastDelimiter == -1)
		  {
		    lastDelimiter = ctfFilePath.LastIndexOf(@"\");
		  }

          ctfFilePath= ctfFilePath.Remove(lastDelimiter, (ctfFilePath.Length - lastDelimiter));

          string ctfFileName = "MatlabFuncs.ctf";

          Stream embeddedCtfStream = null;

          String[] resourceStrings = assembly.GetManifestResourceNames();

          foreach (String name in resourceStrings)
          {
            if (name.Contains(ctfFileName))
            {
              embeddedCtfStream = assembly.GetManifestResourceStream(name);
              break;
            }
          }
          mcr= new MWMCR("",
                         ctfFilePath, embeddedCtfStream, true);
        }
        catch(Exception ex)
        {
          ex_ = new Exception("MWArray assembly failed to be initialized", ex);
        }
      }
      else
      {
        ex_ = new ApplicationException("MWArray assembly could not be initialized");
      }
    }


    /// <summary>
    /// Constructs a new instance of the Funcs class.
    /// </summary>
    public Funcs()
    {
      if(ex_ != null)
      {
        throw ex_;
      }
    }


    #endregion Constructors

    #region Finalize

    /// <summary internal= "true">
    /// Class destructor called by the CLR garbage collector.
    /// </summary>
    ~Funcs()
    {
      Dispose(false);
    }


    /// <summary>
    /// Frees the native resources associated with this object
    /// </summary>
    public void Dispose()
    {
      Dispose(true);

      GC.SuppressFinalize(this);
    }


    /// <summary internal= "true">
    /// Internal dispose function
    /// </summary>
    protected virtual void Dispose(bool disposing)
    {
      if (!disposed)
      {
        disposed= true;

        if (disposing)
        {
          // Free managed resources;
        }

        // Free native resources
      }
    }


    #endregion Finalize

    #region Methods

    /// <summary>
    /// Provides a single output, 0-input MWArrayinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray CreateFiles()
    {
      return mcr.EvaluateFunction("CreateFiles", new MWArray[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input MWArrayinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray CreateFiles(MWArray N)
    {
      return mcr.EvaluateFunction("CreateFiles", N);
    }


    /// <summary>
    /// Provides a single output, 2-input MWArrayinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray CreateFiles(MWArray N, MWArray Mu)
    {
      return mcr.EvaluateFunction("CreateFiles", N, Mu);
    }


    /// <summary>
    /// Provides a single output, 3-input MWArrayinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray CreateFiles(MWArray N, MWArray Mu, MWArray Mv)
    {
      return mcr.EvaluateFunction("CreateFiles", N, Mu, Mv);
    }


    /// <summary>
    /// Provides a single output, 4-input MWArrayinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray CreateFiles(MWArray N, MWArray Mu, MWArray Mv, MWArray Um)
    {
      return mcr.EvaluateFunction("CreateFiles", N, Mu, Mv, Um);
    }


    /// <summary>
    /// Provides a single output, 5-input MWArrayinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray CreateFiles(MWArray N, MWArray Mu, MWArray Mv, MWArray Um, MWArray Vm)
    {
      return mcr.EvaluateFunction("CreateFiles", N, Mu, Mv, Um, Vm);
    }


    /// <summary>
    /// Provides a single output, 6-input MWArrayinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="du">Input argument #6</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray CreateFiles(MWArray N, MWArray Mu, MWArray Mv, MWArray Um, MWArray Vm, 
                         MWArray du)
    {
      return mcr.EvaluateFunction("CreateFiles", N, Mu, Mv, Um, Vm, du);
    }


    /// <summary>
    /// Provides a single output, 7-input MWArrayinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="du">Input argument #6</param>
    /// <param name="dv">Input argument #7</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray CreateFiles(MWArray N, MWArray Mu, MWArray Mv, MWArray Um, MWArray Vm, 
                         MWArray du, MWArray dv)
    {
      return mcr.EvaluateFunction("CreateFiles", N, Mu, Mv, Um, Vm, du, dv);
    }


    /// <summary>
    /// Provides a single output, 8-input MWArrayinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="du">Input argument #6</param>
    /// <param name="dv">Input argument #7</param>
    /// <param name="u">Input argument #8</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray CreateFiles(MWArray N, MWArray Mu, MWArray Mv, MWArray Um, MWArray Vm, 
                         MWArray du, MWArray dv, MWArray u)
    {
      return mcr.EvaluateFunction("CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u);
    }


    /// <summary>
    /// Provides a single output, 9-input MWArrayinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="du">Input argument #6</param>
    /// <param name="dv">Input argument #7</param>
    /// <param name="u">Input argument #8</param>
    /// <param name="v">Input argument #9</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray CreateFiles(MWArray N, MWArray Mu, MWArray Mv, MWArray Um, MWArray Vm, 
                         MWArray du, MWArray dv, MWArray u, MWArray v)
    {
      return mcr.EvaluateFunction("CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v);
    }


    /// <summary>
    /// Provides a single output, 10-input MWArrayinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="du">Input argument #6</param>
    /// <param name="dv">Input argument #7</param>
    /// <param name="u">Input argument #8</param>
    /// <param name="v">Input argument #9</param>
    /// <param name="a">Input argument #10</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray CreateFiles(MWArray N, MWArray Mu, MWArray Mv, MWArray Um, MWArray Vm, 
                         MWArray du, MWArray dv, MWArray u, MWArray v, MWArray a)
    {
      return mcr.EvaluateFunction("CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a);
    }


    /// <summary>
    /// Provides a single output, 11-input MWArrayinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="du">Input argument #6</param>
    /// <param name="dv">Input argument #7</param>
    /// <param name="u">Input argument #8</param>
    /// <param name="v">Input argument #9</param>
    /// <param name="a">Input argument #10</param>
    /// <param name="Tc">Input argument #11</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray CreateFiles(MWArray N, MWArray Mu, MWArray Mv, MWArray Um, MWArray Vm, 
                         MWArray du, MWArray dv, MWArray u, MWArray v, MWArray a, MWArray 
                         Tc)
    {
      return mcr.EvaluateFunction("CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc);
    }


    /// <summary>
    /// Provides a single output, 12-input MWArrayinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="du">Input argument #6</param>
    /// <param name="dv">Input argument #7</param>
    /// <param name="u">Input argument #8</param>
    /// <param name="v">Input argument #9</param>
    /// <param name="a">Input argument #10</param>
    /// <param name="Tc">Input argument #11</param>
    /// <param name="up1">Input argument #12</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray CreateFiles(MWArray N, MWArray Mu, MWArray Mv, MWArray Um, MWArray Vm, 
                         MWArray du, MWArray dv, MWArray u, MWArray v, MWArray a, MWArray 
                         Tc, MWArray up1)
    {
      return mcr.EvaluateFunction("CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc, up1);
    }


    /// <summary>
    /// Provides a single output, 13-input MWArrayinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="du">Input argument #6</param>
    /// <param name="dv">Input argument #7</param>
    /// <param name="u">Input argument #8</param>
    /// <param name="v">Input argument #9</param>
    /// <param name="a">Input argument #10</param>
    /// <param name="Tc">Input argument #11</param>
    /// <param name="up1">Input argument #12</param>
    /// <param name="up2">Input argument #13</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray CreateFiles(MWArray N, MWArray Mu, MWArray Mv, MWArray Um, MWArray Vm, 
                         MWArray du, MWArray dv, MWArray u, MWArray v, MWArray a, MWArray 
                         Tc, MWArray up1, MWArray up2)
    {
      return mcr.EvaluateFunction("CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc, up1, up2);
    }


    /// <summary>
    /// Provides a single output, 14-input MWArrayinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="du">Input argument #6</param>
    /// <param name="dv">Input argument #7</param>
    /// <param name="u">Input argument #8</param>
    /// <param name="v">Input argument #9</param>
    /// <param name="a">Input argument #10</param>
    /// <param name="Tc">Input argument #11</param>
    /// <param name="up1">Input argument #12</param>
    /// <param name="up2">Input argument #13</param>
    /// <param name="vp1">Input argument #14</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray CreateFiles(MWArray N, MWArray Mu, MWArray Mv, MWArray Um, MWArray Vm, 
                         MWArray du, MWArray dv, MWArray u, MWArray v, MWArray a, MWArray 
                         Tc, MWArray up1, MWArray up2, MWArray vp1)
    {
      return mcr.EvaluateFunction("CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc, up1, up2, vp1);
    }


    /// <summary>
    /// Provides a single output, 15-input MWArrayinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="du">Input argument #6</param>
    /// <param name="dv">Input argument #7</param>
    /// <param name="u">Input argument #8</param>
    /// <param name="v">Input argument #9</param>
    /// <param name="a">Input argument #10</param>
    /// <param name="Tc">Input argument #11</param>
    /// <param name="up1">Input argument #12</param>
    /// <param name="up2">Input argument #13</param>
    /// <param name="vp1">Input argument #14</param>
    /// <param name="vp2">Input argument #15</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray CreateFiles(MWArray N, MWArray Mu, MWArray Mv, MWArray Um, MWArray Vm, 
                         MWArray du, MWArray dv, MWArray u, MWArray v, MWArray a, MWArray 
                         Tc, MWArray up1, MWArray up2, MWArray vp1, MWArray vp2)
    {
      return mcr.EvaluateFunction("CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc, up1, up2, vp1, vp2);
    }


    /// <summary>
    /// Provides a single output, 16-input MWArrayinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="du">Input argument #6</param>
    /// <param name="dv">Input argument #7</param>
    /// <param name="u">Input argument #8</param>
    /// <param name="v">Input argument #9</param>
    /// <param name="a">Input argument #10</param>
    /// <param name="Tc">Input argument #11</param>
    /// <param name="up1">Input argument #12</param>
    /// <param name="up2">Input argument #13</param>
    /// <param name="vp1">Input argument #14</param>
    /// <param name="vp2">Input argument #15</param>
    /// <param name="Ap1">Input argument #16</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray CreateFiles(MWArray N, MWArray Mu, MWArray Mv, MWArray Um, MWArray Vm, 
                         MWArray du, MWArray dv, MWArray u, MWArray v, MWArray a, MWArray 
                         Tc, MWArray up1, MWArray up2, MWArray vp1, MWArray vp2, MWArray 
                         Ap1)
    {
      return mcr.EvaluateFunction("CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc, up1, up2, vp1, vp2, Ap1);
    }


    /// <summary>
    /// Provides a single output, 17-input MWArrayinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="du">Input argument #6</param>
    /// <param name="dv">Input argument #7</param>
    /// <param name="u">Input argument #8</param>
    /// <param name="v">Input argument #9</param>
    /// <param name="a">Input argument #10</param>
    /// <param name="Tc">Input argument #11</param>
    /// <param name="up1">Input argument #12</param>
    /// <param name="up2">Input argument #13</param>
    /// <param name="vp1">Input argument #14</param>
    /// <param name="vp2">Input argument #15</param>
    /// <param name="Ap1">Input argument #16</param>
    /// <param name="Ap2">Input argument #17</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray CreateFiles(MWArray N, MWArray Mu, MWArray Mv, MWArray Um, MWArray Vm, 
                         MWArray du, MWArray dv, MWArray u, MWArray v, MWArray a, MWArray 
                         Tc, MWArray up1, MWArray up2, MWArray vp1, MWArray vp2, MWArray 
                         Ap1, MWArray Ap2)
    {
      return mcr.EvaluateFunction("CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc, up1, up2, vp1, vp2, Ap1, Ap2);
    }


    /// <summary>
    /// Provides a single output, 18-input MWArrayinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="du">Input argument #6</param>
    /// <param name="dv">Input argument #7</param>
    /// <param name="u">Input argument #8</param>
    /// <param name="v">Input argument #9</param>
    /// <param name="a">Input argument #10</param>
    /// <param name="Tc">Input argument #11</param>
    /// <param name="up1">Input argument #12</param>
    /// <param name="up2">Input argument #13</param>
    /// <param name="vp1">Input argument #14</param>
    /// <param name="vp2">Input argument #15</param>
    /// <param name="Ap1">Input argument #16</param>
    /// <param name="Ap2">Input argument #17</param>
    /// <param name="gamma">Input argument #18</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray CreateFiles(MWArray N, MWArray Mu, MWArray Mv, MWArray Um, MWArray Vm, 
                         MWArray du, MWArray dv, MWArray u, MWArray v, MWArray a, MWArray 
                         Tc, MWArray up1, MWArray up2, MWArray vp1, MWArray vp2, MWArray 
                         Ap1, MWArray Ap2, MWArray gamma)
    {
      return mcr.EvaluateFunction("CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc, up1, up2, vp1, vp2, Ap1, Ap2, gamma);
    }


    /// <summary>
    /// Provides a single output, 19-input MWArrayinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="du">Input argument #6</param>
    /// <param name="dv">Input argument #7</param>
    /// <param name="u">Input argument #8</param>
    /// <param name="v">Input argument #9</param>
    /// <param name="a">Input argument #10</param>
    /// <param name="Tc">Input argument #11</param>
    /// <param name="up1">Input argument #12</param>
    /// <param name="up2">Input argument #13</param>
    /// <param name="vp1">Input argument #14</param>
    /// <param name="vp2">Input argument #15</param>
    /// <param name="Ap1">Input argument #16</param>
    /// <param name="Ap2">Input argument #17</param>
    /// <param name="gamma">Input argument #18</param>
    /// <param name="mu">Input argument #19</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray CreateFiles(MWArray N, MWArray Mu, MWArray Mv, MWArray Um, MWArray Vm, 
                         MWArray du, MWArray dv, MWArray u, MWArray v, MWArray a, MWArray 
                         Tc, MWArray up1, MWArray up2, MWArray vp1, MWArray vp2, MWArray 
                         Ap1, MWArray Ap2, MWArray gamma, MWArray mu)
    {
      return mcr.EvaluateFunction("CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc, up1, up2, vp1, vp2, Ap1, Ap2, gamma, mu);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CreateFiles(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CreateFiles(int numArgsOut, MWArray N)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", N);
    }


    /// <summary>
    /// Provides the standard 2-input MWArray interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CreateFiles(int numArgsOut, MWArray N, MWArray Mu)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", N, Mu);
    }


    /// <summary>
    /// Provides the standard 3-input MWArray interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CreateFiles(int numArgsOut, MWArray N, MWArray Mu, MWArray Mv)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", N, Mu, Mv);
    }


    /// <summary>
    /// Provides the standard 4-input MWArray interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CreateFiles(int numArgsOut, MWArray N, MWArray Mu, MWArray Mv, 
                           MWArray Um)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", N, Mu, Mv, Um);
    }


    /// <summary>
    /// Provides the standard 5-input MWArray interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CreateFiles(int numArgsOut, MWArray N, MWArray Mu, MWArray Mv, 
                           MWArray Um, MWArray Vm)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", N, Mu, Mv, Um, Vm);
    }


    /// <summary>
    /// Provides the standard 6-input MWArray interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="du">Input argument #6</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CreateFiles(int numArgsOut, MWArray N, MWArray Mu, MWArray Mv, 
                           MWArray Um, MWArray Vm, MWArray du)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", N, Mu, Mv, Um, Vm, du);
    }


    /// <summary>
    /// Provides the standard 7-input MWArray interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="du">Input argument #6</param>
    /// <param name="dv">Input argument #7</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CreateFiles(int numArgsOut, MWArray N, MWArray Mu, MWArray Mv, 
                           MWArray Um, MWArray Vm, MWArray du, MWArray dv)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", N, Mu, Mv, Um, Vm, du, dv);
    }


    /// <summary>
    /// Provides the standard 8-input MWArray interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="du">Input argument #6</param>
    /// <param name="dv">Input argument #7</param>
    /// <param name="u">Input argument #8</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CreateFiles(int numArgsOut, MWArray N, MWArray Mu, MWArray Mv, 
                           MWArray Um, MWArray Vm, MWArray du, MWArray dv, MWArray u)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u);
    }


    /// <summary>
    /// Provides the standard 9-input MWArray interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="du">Input argument #6</param>
    /// <param name="dv">Input argument #7</param>
    /// <param name="u">Input argument #8</param>
    /// <param name="v">Input argument #9</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CreateFiles(int numArgsOut, MWArray N, MWArray Mu, MWArray Mv, 
                           MWArray Um, MWArray Vm, MWArray du, MWArray dv, MWArray u, 
                           MWArray v)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v);
    }


    /// <summary>
    /// Provides the standard 10-input MWArray interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="du">Input argument #6</param>
    /// <param name="dv">Input argument #7</param>
    /// <param name="u">Input argument #8</param>
    /// <param name="v">Input argument #9</param>
    /// <param name="a">Input argument #10</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CreateFiles(int numArgsOut, MWArray N, MWArray Mu, MWArray Mv, 
                           MWArray Um, MWArray Vm, MWArray du, MWArray dv, MWArray u, 
                           MWArray v, MWArray a)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a);
    }


    /// <summary>
    /// Provides the standard 11-input MWArray interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="du">Input argument #6</param>
    /// <param name="dv">Input argument #7</param>
    /// <param name="u">Input argument #8</param>
    /// <param name="v">Input argument #9</param>
    /// <param name="a">Input argument #10</param>
    /// <param name="Tc">Input argument #11</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CreateFiles(int numArgsOut, MWArray N, MWArray Mu, MWArray Mv, 
                           MWArray Um, MWArray Vm, MWArray du, MWArray dv, MWArray u, 
                           MWArray v, MWArray a, MWArray Tc)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc);
    }


    /// <summary>
    /// Provides the standard 12-input MWArray interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="du">Input argument #6</param>
    /// <param name="dv">Input argument #7</param>
    /// <param name="u">Input argument #8</param>
    /// <param name="v">Input argument #9</param>
    /// <param name="a">Input argument #10</param>
    /// <param name="Tc">Input argument #11</param>
    /// <param name="up1">Input argument #12</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CreateFiles(int numArgsOut, MWArray N, MWArray Mu, MWArray Mv, 
                           MWArray Um, MWArray Vm, MWArray du, MWArray dv, MWArray u, 
                           MWArray v, MWArray a, MWArray Tc, MWArray up1)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc, up1);
    }


    /// <summary>
    /// Provides the standard 13-input MWArray interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="du">Input argument #6</param>
    /// <param name="dv">Input argument #7</param>
    /// <param name="u">Input argument #8</param>
    /// <param name="v">Input argument #9</param>
    /// <param name="a">Input argument #10</param>
    /// <param name="Tc">Input argument #11</param>
    /// <param name="up1">Input argument #12</param>
    /// <param name="up2">Input argument #13</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CreateFiles(int numArgsOut, MWArray N, MWArray Mu, MWArray Mv, 
                           MWArray Um, MWArray Vm, MWArray du, MWArray dv, MWArray u, 
                           MWArray v, MWArray a, MWArray Tc, MWArray up1, MWArray up2)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc, up1, up2);
    }


    /// <summary>
    /// Provides the standard 14-input MWArray interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="du">Input argument #6</param>
    /// <param name="dv">Input argument #7</param>
    /// <param name="u">Input argument #8</param>
    /// <param name="v">Input argument #9</param>
    /// <param name="a">Input argument #10</param>
    /// <param name="Tc">Input argument #11</param>
    /// <param name="up1">Input argument #12</param>
    /// <param name="up2">Input argument #13</param>
    /// <param name="vp1">Input argument #14</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CreateFiles(int numArgsOut, MWArray N, MWArray Mu, MWArray Mv, 
                           MWArray Um, MWArray Vm, MWArray du, MWArray dv, MWArray u, 
                           MWArray v, MWArray a, MWArray Tc, MWArray up1, MWArray up2, 
                           MWArray vp1)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc, up1, up2, vp1);
    }


    /// <summary>
    /// Provides the standard 15-input MWArray interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="du">Input argument #6</param>
    /// <param name="dv">Input argument #7</param>
    /// <param name="u">Input argument #8</param>
    /// <param name="v">Input argument #9</param>
    /// <param name="a">Input argument #10</param>
    /// <param name="Tc">Input argument #11</param>
    /// <param name="up1">Input argument #12</param>
    /// <param name="up2">Input argument #13</param>
    /// <param name="vp1">Input argument #14</param>
    /// <param name="vp2">Input argument #15</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CreateFiles(int numArgsOut, MWArray N, MWArray Mu, MWArray Mv, 
                           MWArray Um, MWArray Vm, MWArray du, MWArray dv, MWArray u, 
                           MWArray v, MWArray a, MWArray Tc, MWArray up1, MWArray up2, 
                           MWArray vp1, MWArray vp2)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc, up1, up2, vp1, vp2);
    }


    /// <summary>
    /// Provides the standard 16-input MWArray interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="du">Input argument #6</param>
    /// <param name="dv">Input argument #7</param>
    /// <param name="u">Input argument #8</param>
    /// <param name="v">Input argument #9</param>
    /// <param name="a">Input argument #10</param>
    /// <param name="Tc">Input argument #11</param>
    /// <param name="up1">Input argument #12</param>
    /// <param name="up2">Input argument #13</param>
    /// <param name="vp1">Input argument #14</param>
    /// <param name="vp2">Input argument #15</param>
    /// <param name="Ap1">Input argument #16</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CreateFiles(int numArgsOut, MWArray N, MWArray Mu, MWArray Mv, 
                           MWArray Um, MWArray Vm, MWArray du, MWArray dv, MWArray u, 
                           MWArray v, MWArray a, MWArray Tc, MWArray up1, MWArray up2, 
                           MWArray vp1, MWArray vp2, MWArray Ap1)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc, up1, up2, vp1, vp2, Ap1);
    }


    /// <summary>
    /// Provides the standard 17-input MWArray interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="du">Input argument #6</param>
    /// <param name="dv">Input argument #7</param>
    /// <param name="u">Input argument #8</param>
    /// <param name="v">Input argument #9</param>
    /// <param name="a">Input argument #10</param>
    /// <param name="Tc">Input argument #11</param>
    /// <param name="up1">Input argument #12</param>
    /// <param name="up2">Input argument #13</param>
    /// <param name="vp1">Input argument #14</param>
    /// <param name="vp2">Input argument #15</param>
    /// <param name="Ap1">Input argument #16</param>
    /// <param name="Ap2">Input argument #17</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CreateFiles(int numArgsOut, MWArray N, MWArray Mu, MWArray Mv, 
                           MWArray Um, MWArray Vm, MWArray du, MWArray dv, MWArray u, 
                           MWArray v, MWArray a, MWArray Tc, MWArray up1, MWArray up2, 
                           MWArray vp1, MWArray vp2, MWArray Ap1, MWArray Ap2)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc, up1, up2, vp1, vp2, Ap1, Ap2);
    }


    /// <summary>
    /// Provides the standard 18-input MWArray interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="du">Input argument #6</param>
    /// <param name="dv">Input argument #7</param>
    /// <param name="u">Input argument #8</param>
    /// <param name="v">Input argument #9</param>
    /// <param name="a">Input argument #10</param>
    /// <param name="Tc">Input argument #11</param>
    /// <param name="up1">Input argument #12</param>
    /// <param name="up2">Input argument #13</param>
    /// <param name="vp1">Input argument #14</param>
    /// <param name="vp2">Input argument #15</param>
    /// <param name="Ap1">Input argument #16</param>
    /// <param name="Ap2">Input argument #17</param>
    /// <param name="gamma">Input argument #18</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CreateFiles(int numArgsOut, MWArray N, MWArray Mu, MWArray Mv, 
                           MWArray Um, MWArray Vm, MWArray du, MWArray dv, MWArray u, 
                           MWArray v, MWArray a, MWArray Tc, MWArray up1, MWArray up2, 
                           MWArray vp1, MWArray vp2, MWArray Ap1, MWArray Ap2, MWArray 
                           gamma)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc, up1, up2, vp1, vp2, Ap1, Ap2, gamma);
    }


    /// <summary>
    /// Provides the standard 19-input MWArray interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="du">Input argument #6</param>
    /// <param name="dv">Input argument #7</param>
    /// <param name="u">Input argument #8</param>
    /// <param name="v">Input argument #9</param>
    /// <param name="a">Input argument #10</param>
    /// <param name="Tc">Input argument #11</param>
    /// <param name="up1">Input argument #12</param>
    /// <param name="up2">Input argument #13</param>
    /// <param name="vp1">Input argument #14</param>
    /// <param name="vp2">Input argument #15</param>
    /// <param name="Ap1">Input argument #16</param>
    /// <param name="Ap2">Input argument #17</param>
    /// <param name="gamma">Input argument #18</param>
    /// <param name="mu">Input argument #19</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CreateFiles(int numArgsOut, MWArray N, MWArray Mu, MWArray Mv, 
                           MWArray Um, MWArray Vm, MWArray du, MWArray dv, MWArray u, 
                           MWArray v, MWArray a, MWArray Tc, MWArray up1, MWArray up2, 
                           MWArray vp1, MWArray vp2, MWArray Ap1, MWArray Ap2, MWArray 
                           gamma, MWArray mu)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc, up1, up2, vp1, vp2, Ap1, Ap2, gamma, mu);
    }


    /// <summary>
    /// Provides an interface for the CreateFiles function in which the input and output
    /// arguments are specified as an array of MWArrays.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// --ФОРМИРОВАНИЕ МАССИВА ВЕКТРОВ ОГИБАЮЩЕЙ
    /// СИГНАЛА ДЛЯ ВСЕХ ГИПОТЕЗ ПО УГЛУ-
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of MWArray output arguments</param>
    /// <param name= "argsIn">Array of MWArray input arguments</param>
    ///
    public void CreateFiles(int numArgsOut, ref MWArray[] argsOut, MWArray[] argsIn)
    {
      mcr.EvaluateFunction("CreateFiles", numArgsOut, ref argsOut, argsIn);
    }


    /// <summary>
    /// Provides a single output, 0-input MWArrayinterface to the CreateL MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray CreateL()
    {
      return mcr.EvaluateFunction("CreateL", new MWArray[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input MWArrayinterface to the CreateL MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray CreateL(MWArray N)
    {
      return mcr.EvaluateFunction("CreateL", N);
    }


    /// <summary>
    /// Provides a single output, 2-input MWArrayinterface to the CreateL MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray CreateL(MWArray N, MWArray Mu)
    {
      return mcr.EvaluateFunction("CreateL", N, Mu);
    }


    /// <summary>
    /// Provides a single output, 3-input MWArrayinterface to the CreateL MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray CreateL(MWArray N, MWArray Mu, MWArray Mv)
    {
      return mcr.EvaluateFunction("CreateL", N, Mu, Mv);
    }


    /// <summary>
    /// Provides a single output, 4-input MWArrayinterface to the CreateL MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray CreateL(MWArray N, MWArray Mu, MWArray Mv, MWArray Um)
    {
      return mcr.EvaluateFunction("CreateL", N, Mu, Mv, Um);
    }


    /// <summary>
    /// Provides a single output, 5-input MWArrayinterface to the CreateL MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray CreateL(MWArray N, MWArray Mu, MWArray Mv, MWArray Um, MWArray Vm)
    {
      return mcr.EvaluateFunction("CreateL", N, Mu, Mv, Um, Vm);
    }


    /// <summary>
    /// Provides a single output, 6-input MWArrayinterface to the CreateL MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="mu">Input argument #6</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray CreateL(MWArray N, MWArray Mu, MWArray Mv, MWArray Um, MWArray Vm, 
                     MWArray mu)
    {
      return mcr.EvaluateFunction("CreateL", N, Mu, Mv, Um, Vm, mu);
    }


    /// <summary>
    /// Provides a single output, 7-input MWArrayinterface to the CreateL MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="mu">Input argument #6</param>
    /// <param name="expH">Input argument #7</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray CreateL(MWArray N, MWArray Mu, MWArray Mv, MWArray Um, MWArray Vm, 
                     MWArray mu, MWArray expH)
    {
      return mcr.EvaluateFunction("CreateL", N, Mu, Mv, Um, Vm, mu, expH);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the CreateL MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CreateL(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateL", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the CreateL MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CreateL(int numArgsOut, MWArray N)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateL", N);
    }


    /// <summary>
    /// Provides the standard 2-input MWArray interface to the CreateL MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CreateL(int numArgsOut, MWArray N, MWArray Mu)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateL", N, Mu);
    }


    /// <summary>
    /// Provides the standard 3-input MWArray interface to the CreateL MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CreateL(int numArgsOut, MWArray N, MWArray Mu, MWArray Mv)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateL", N, Mu, Mv);
    }


    /// <summary>
    /// Provides the standard 4-input MWArray interface to the CreateL MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CreateL(int numArgsOut, MWArray N, MWArray Mu, MWArray Mv, MWArray 
                       Um)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateL", N, Mu, Mv, Um);
    }


    /// <summary>
    /// Provides the standard 5-input MWArray interface to the CreateL MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CreateL(int numArgsOut, MWArray N, MWArray Mu, MWArray Mv, MWArray 
                       Um, MWArray Vm)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateL", N, Mu, Mv, Um, Vm);
    }


    /// <summary>
    /// Provides the standard 6-input MWArray interface to the CreateL MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="mu">Input argument #6</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CreateL(int numArgsOut, MWArray N, MWArray Mu, MWArray Mv, MWArray 
                       Um, MWArray Vm, MWArray mu)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateL", N, Mu, Mv, Um, Vm, mu);
    }


    /// <summary>
    /// Provides the standard 7-input MWArray interface to the CreateL MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="mu">Input argument #6</param>
    /// <param name="expH">Input argument #7</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CreateL(int numArgsOut, MWArray N, MWArray Mu, MWArray Mv, MWArray 
                       Um, MWArray Vm, MWArray mu, MWArray expH)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateL", N, Mu, Mv, Um, Vm, mu, expH);
    }


    /// <summary>
    /// Provides an interface for the CreateL function in which the input and output
    /// arguments are specified as an array of MWArrays.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of MWArray output arguments</param>
    /// <param name= "argsIn">Array of MWArray input arguments</param>
    ///
    public void CreateL(int numArgsOut, ref MWArray[] argsOut, MWArray[] argsIn)
    {
      mcr.EvaluateFunction("CreateL", numArgsOut, ref argsOut, argsIn);
    }


    /// <summary>
    /// Provides a single output, 0-input MWArrayinterface to the CreatePicture MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// hypothetical signals information
    /// </remarks>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray CreatePicture()
    {
      return mcr.EvaluateFunction("CreatePicture", new MWArray[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input MWArrayinterface to the CreatePicture MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// hypothetical signals information
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray CreatePicture(MWArray N)
    {
      return mcr.EvaluateFunction("CreatePicture", N);
    }


    /// <summary>
    /// Provides a single output, 2-input MWArrayinterface to the CreatePicture MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// hypothetical signals information
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray CreatePicture(MWArray N, MWArray Mu)
    {
      return mcr.EvaluateFunction("CreatePicture", N, Mu);
    }


    /// <summary>
    /// Provides a single output, 3-input MWArrayinterface to the CreatePicture MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// hypothetical signals information
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray CreatePicture(MWArray N, MWArray Mu, MWArray Mv)
    {
      return mcr.EvaluateFunction("CreatePicture", N, Mu, Mv);
    }


    /// <summary>
    /// Provides a single output, 4-input MWArrayinterface to the CreatePicture MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// hypothetical signals information
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray CreatePicture(MWArray N, MWArray Mu, MWArray Mv, MWArray Um)
    {
      return mcr.EvaluateFunction("CreatePicture", N, Mu, Mv, Um);
    }


    /// <summary>
    /// Provides a single output, 5-input MWArrayinterface to the CreatePicture MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// hypothetical signals information
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray CreatePicture(MWArray N, MWArray Mu, MWArray Mv, MWArray Um, MWArray 
                           Vm)
    {
      return mcr.EvaluateFunction("CreatePicture", N, Mu, Mv, Um, Vm);
    }


    /// <summary>
    /// Provides a single output, 6-input MWArrayinterface to the CreatePicture MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// hypothetical signals information
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="expH">Input argument #6</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray CreatePicture(MWArray N, MWArray Mu, MWArray Mv, MWArray Um, MWArray 
                           Vm, MWArray expH)
    {
      return mcr.EvaluateFunction("CreatePicture", N, Mu, Mv, Um, Vm, expH);
    }


    /// <summary>
    /// Provides a single output, 7-input MWArrayinterface to the CreatePicture MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// hypothetical signals information
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="expH">Input argument #6</param>
    /// <param name="filecode">Input argument #7</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray CreatePicture(MWArray N, MWArray Mu, MWArray Mv, MWArray Um, MWArray 
                           Vm, MWArray expH, MWArray filecode)
    {
      return mcr.EvaluateFunction("CreatePicture", N, Mu, Mv, Um, Vm, expH, filecode);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the CreatePicture MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// hypothetical signals information
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CreatePicture(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreatePicture", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the CreatePicture MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// hypothetical signals information
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CreatePicture(int numArgsOut, MWArray N)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreatePicture", N);
    }


    /// <summary>
    /// Provides the standard 2-input MWArray interface to the CreatePicture MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// hypothetical signals information
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CreatePicture(int numArgsOut, MWArray N, MWArray Mu)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreatePicture", N, Mu);
    }


    /// <summary>
    /// Provides the standard 3-input MWArray interface to the CreatePicture MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// hypothetical signals information
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CreatePicture(int numArgsOut, MWArray N, MWArray Mu, MWArray Mv)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreatePicture", N, Mu, Mv);
    }


    /// <summary>
    /// Provides the standard 4-input MWArray interface to the CreatePicture MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// hypothetical signals information
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CreatePicture(int numArgsOut, MWArray N, MWArray Mu, MWArray Mv, 
                             MWArray Um)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreatePicture", N, Mu, Mv, Um);
    }


    /// <summary>
    /// Provides the standard 5-input MWArray interface to the CreatePicture MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// hypothetical signals information
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CreatePicture(int numArgsOut, MWArray N, MWArray Mu, MWArray Mv, 
                             MWArray Um, MWArray Vm)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreatePicture", N, Mu, Mv, Um, Vm);
    }


    /// <summary>
    /// Provides the standard 6-input MWArray interface to the CreatePicture MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// hypothetical signals information
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="expH">Input argument #6</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CreatePicture(int numArgsOut, MWArray N, MWArray Mu, MWArray Mv, 
                             MWArray Um, MWArray Vm, MWArray expH)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreatePicture", N, Mu, Mv, Um, Vm, expH);
    }


    /// <summary>
    /// Provides the standard 7-input MWArray interface to the CreatePicture MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// hypothetical signals information
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="expH">Input argument #6</param>
    /// <param name="filecode">Input argument #7</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] CreatePicture(int numArgsOut, MWArray N, MWArray Mu, MWArray Mv, 
                             MWArray Um, MWArray Vm, MWArray expH, MWArray filecode)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreatePicture", N, Mu, Mv, Um, Vm, expH, filecode);
    }


    /// <summary>
    /// Provides an interface for the CreatePicture function in which the input and
    /// output
    /// arguments are specified as an array of MWArrays.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// hypothetical signals information
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of MWArray output arguments</param>
    /// <param name= "argsIn">Array of MWArray input arguments</param>
    ///
    public void CreatePicture(int numArgsOut, ref MWArray[] argsOut, MWArray[] argsIn)
    {
      mcr.EvaluateFunction("CreatePicture", numArgsOut, ref argsOut, argsIn);
    }



    /// <summary>
    /// This method will cause a MATLAB figure window to behave as a modal dialog box.
    /// The method will not return until all the figure windows associated with this
    /// component have been closed.
    /// </summary>
    /// <remarks>
    /// An application should only call this method when required to keep the
    /// MATLAB figure window from disappearing.  Other techniques, such as calling
    /// Console.ReadLine() from the application should be considered where
    /// possible.</remarks>
    ///
    public void WaitForFiguresToDie()
    {
      mcr.WaitForFiguresToDie();
    }



    #endregion Methods

    #region Class Members

    private static MWMCR mcr= null;

    private static Exception ex_= null;

    private bool disposed= false;

    #endregion Class Members
  }
}
