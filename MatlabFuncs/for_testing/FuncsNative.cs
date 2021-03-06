/*
* MATLAB Compiler: 8.0 (R2020a)
* Date: Wed May 13 19:16:49 2020
* Arguments:
* "-B""macro_default""-W""dotnet:MatlabFuncs,Funcs,4.0,private,version=1.0""-T""link:lib""
* -d""C:\Users\Natalya\Desktop\Coursework\MatlabFucs\for_testing""-v""class{Funcs:C:\Users
* \Natalya\Desktop\Coursework\溷妯╘CreateFiles.m,C:\Users\Natalya\Desktop\Coursework\溷
* 妯╘CreateL.m,C:\Users\Natalya\Desktop\Coursework\溷妯╘CreatePicture.m}"
*/
using System;
using System.Reflection;
using System.IO;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

#if SHARED
[assembly: System.Reflection.AssemblyKeyFile(@"")]
#endif

namespace MatlabFuncsNative
{

  /// <summary>
  /// The Funcs class provides a CLS compliant, Object (native) interface to the MATLAB
  /// functions contained in the files:
  /// <newpara></newpara>
  /// C:\Users\Natalya\Desktop\Coursework\趔黻鲨鑌CreateFiles.m
  /// <newpara></newpara>
  /// C:\Users\Natalya\Desktop\Coursework\趔黻鲨鑌CreateL.m
  /// <newpara></newpara>
  /// C:\Users\Natalya\Desktop\Coursework\趔黻鲨鑌CreatePicture.m
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
    /// Provides a single output, 0-input Objectinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
    /// </remarks>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object CreateFiles()
    {
      return mcr.EvaluateFunction("CreateFiles", new Object[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input Objectinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object CreateFiles(Object N)
    {
      return mcr.EvaluateFunction("CreateFiles", N);
    }


    /// <summary>
    /// Provides a single output, 2-input Objectinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object CreateFiles(Object N, Object Mu)
    {
      return mcr.EvaluateFunction("CreateFiles", N, Mu);
    }


    /// <summary>
    /// Provides a single output, 3-input Objectinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object CreateFiles(Object N, Object Mu, Object Mv)
    {
      return mcr.EvaluateFunction("CreateFiles", N, Mu, Mv);
    }


    /// <summary>
    /// Provides a single output, 4-input Objectinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object CreateFiles(Object N, Object Mu, Object Mv, Object Um)
    {
      return mcr.EvaluateFunction("CreateFiles", N, Mu, Mv, Um);
    }


    /// <summary>
    /// Provides a single output, 5-input Objectinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object CreateFiles(Object N, Object Mu, Object Mv, Object Um, Object Vm)
    {
      return mcr.EvaluateFunction("CreateFiles", N, Mu, Mv, Um, Vm);
    }


    /// <summary>
    /// Provides a single output, 6-input Objectinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="du">Input argument #6</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object CreateFiles(Object N, Object Mu, Object Mv, Object Um, Object Vm, 
                        Object du)
    {
      return mcr.EvaluateFunction("CreateFiles", N, Mu, Mv, Um, Vm, du);
    }


    /// <summary>
    /// Provides a single output, 7-input Objectinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="du">Input argument #6</param>
    /// <param name="dv">Input argument #7</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object CreateFiles(Object N, Object Mu, Object Mv, Object Um, Object Vm, 
                        Object du, Object dv)
    {
      return mcr.EvaluateFunction("CreateFiles", N, Mu, Mv, Um, Vm, du, dv);
    }


    /// <summary>
    /// Provides a single output, 8-input Objectinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="du">Input argument #6</param>
    /// <param name="dv">Input argument #7</param>
    /// <param name="u">Input argument #8</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object CreateFiles(Object N, Object Mu, Object Mv, Object Um, Object Vm, 
                        Object du, Object dv, Object u)
    {
      return mcr.EvaluateFunction("CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u);
    }


    /// <summary>
    /// Provides a single output, 9-input Objectinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
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
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object CreateFiles(Object N, Object Mu, Object Mv, Object Um, Object Vm, 
                        Object du, Object dv, Object u, Object v)
    {
      return mcr.EvaluateFunction("CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v);
    }


    /// <summary>
    /// Provides a single output, 10-input Objectinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
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
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object CreateFiles(Object N, Object Mu, Object Mv, Object Um, Object Vm, 
                        Object du, Object dv, Object u, Object v, Object a)
    {
      return mcr.EvaluateFunction("CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a);
    }


    /// <summary>
    /// Provides a single output, 11-input Objectinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
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
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object CreateFiles(Object N, Object Mu, Object Mv, Object Um, Object Vm, 
                        Object du, Object dv, Object u, Object v, Object a, Object Tc)
    {
      return mcr.EvaluateFunction("CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc);
    }


    /// <summary>
    /// Provides a single output, 12-input Objectinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
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
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object CreateFiles(Object N, Object Mu, Object Mv, Object Um, Object Vm, 
                        Object du, Object dv, Object u, Object v, Object a, Object Tc, 
                        Object up1)
    {
      return mcr.EvaluateFunction("CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc, up1);
    }


    /// <summary>
    /// Provides a single output, 13-input Objectinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
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
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object CreateFiles(Object N, Object Mu, Object Mv, Object Um, Object Vm, 
                        Object du, Object dv, Object u, Object v, Object a, Object Tc, 
                        Object up1, Object up2)
    {
      return mcr.EvaluateFunction("CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc, up1, up2);
    }


    /// <summary>
    /// Provides a single output, 14-input Objectinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
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
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object CreateFiles(Object N, Object Mu, Object Mv, Object Um, Object Vm, 
                        Object du, Object dv, Object u, Object v, Object a, Object Tc, 
                        Object up1, Object up2, Object vp1)
    {
      return mcr.EvaluateFunction("CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc, up1, up2, vp1);
    }


    /// <summary>
    /// Provides a single output, 15-input Objectinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
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
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object CreateFiles(Object N, Object Mu, Object Mv, Object Um, Object Vm, 
                        Object du, Object dv, Object u, Object v, Object a, Object Tc, 
                        Object up1, Object up2, Object vp1, Object vp2)
    {
      return mcr.EvaluateFunction("CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc, up1, up2, vp1, vp2);
    }


    /// <summary>
    /// Provides a single output, 16-input Objectinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
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
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object CreateFiles(Object N, Object Mu, Object Mv, Object Um, Object Vm, 
                        Object du, Object dv, Object u, Object v, Object a, Object Tc, 
                        Object up1, Object up2, Object vp1, Object vp2, Object Ap1)
    {
      return mcr.EvaluateFunction("CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc, up1, up2, vp1, vp2, Ap1);
    }


    /// <summary>
    /// Provides a single output, 17-input Objectinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
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
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object CreateFiles(Object N, Object Mu, Object Mv, Object Um, Object Vm, 
                        Object du, Object dv, Object u, Object v, Object a, Object Tc, 
                        Object up1, Object up2, Object vp1, Object vp2, Object Ap1, 
                        Object Ap2)
    {
      return mcr.EvaluateFunction("CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc, up1, up2, vp1, vp2, Ap1, Ap2);
    }


    /// <summary>
    /// Provides a single output, 18-input Objectinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
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
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object CreateFiles(Object N, Object Mu, Object Mv, Object Um, Object Vm, 
                        Object du, Object dv, Object u, Object v, Object a, Object Tc, 
                        Object up1, Object up2, Object vp1, Object vp2, Object Ap1, 
                        Object Ap2, Object gamma)
    {
      return mcr.EvaluateFunction("CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc, up1, up2, vp1, vp2, Ap1, Ap2, gamma);
    }


    /// <summary>
    /// Provides a single output, 19-input Objectinterface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
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
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object CreateFiles(Object N, Object Mu, Object Mv, Object Um, Object Vm, 
                        Object du, Object dv, Object u, Object v, Object a, Object Tc, 
                        Object up1, Object up2, Object vp1, Object vp2, Object Ap1, 
                        Object Ap2, Object gamma, Object mu)
    {
      return mcr.EvaluateFunction("CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc, up1, up2, vp1, vp2, Ap1, Ap2, gamma, mu);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] CreateFiles(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] CreateFiles(int numArgsOut, Object N)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", N);
    }


    /// <summary>
    /// Provides the standard 2-input Object interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] CreateFiles(int numArgsOut, Object N, Object Mu)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", N, Mu);
    }


    /// <summary>
    /// Provides the standard 3-input Object interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] CreateFiles(int numArgsOut, Object N, Object Mu, Object Mv)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", N, Mu, Mv);
    }


    /// <summary>
    /// Provides the standard 4-input Object interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] CreateFiles(int numArgsOut, Object N, Object Mu, Object Mv, Object Um)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", N, Mu, Mv, Um);
    }


    /// <summary>
    /// Provides the standard 5-input Object interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
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
    public Object[] CreateFiles(int numArgsOut, Object N, Object Mu, Object Mv, Object 
                          Um, Object Vm)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", N, Mu, Mv, Um, Vm);
    }


    /// <summary>
    /// Provides the standard 6-input Object interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
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
    public Object[] CreateFiles(int numArgsOut, Object N, Object Mu, Object Mv, Object 
                          Um, Object Vm, Object du)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", N, Mu, Mv, Um, Vm, du);
    }


    /// <summary>
    /// Provides the standard 7-input Object interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
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
    public Object[] CreateFiles(int numArgsOut, Object N, Object Mu, Object Mv, Object 
                          Um, Object Vm, Object du, Object dv)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", N, Mu, Mv, Um, Vm, du, dv);
    }


    /// <summary>
    /// Provides the standard 8-input Object interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
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
    public Object[] CreateFiles(int numArgsOut, Object N, Object Mu, Object Mv, Object 
                          Um, Object Vm, Object du, Object dv, Object u)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u);
    }


    /// <summary>
    /// Provides the standard 9-input Object interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
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
    public Object[] CreateFiles(int numArgsOut, Object N, Object Mu, Object Mv, Object 
                          Um, Object Vm, Object du, Object dv, Object u, Object v)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v);
    }


    /// <summary>
    /// Provides the standard 10-input Object interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
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
    public Object[] CreateFiles(int numArgsOut, Object N, Object Mu, Object Mv, Object 
                          Um, Object Vm, Object du, Object dv, Object u, Object v, Object 
                          a)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a);
    }


    /// <summary>
    /// Provides the standard 11-input Object interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
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
    public Object[] CreateFiles(int numArgsOut, Object N, Object Mu, Object Mv, Object 
                          Um, Object Vm, Object du, Object dv, Object u, Object v, Object 
                          a, Object Tc)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc);
    }


    /// <summary>
    /// Provides the standard 12-input Object interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
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
    public Object[] CreateFiles(int numArgsOut, Object N, Object Mu, Object Mv, Object 
                          Um, Object Vm, Object du, Object dv, Object u, Object v, Object 
                          a, Object Tc, Object up1)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc, up1);
    }


    /// <summary>
    /// Provides the standard 13-input Object interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
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
    public Object[] CreateFiles(int numArgsOut, Object N, Object Mu, Object Mv, Object 
                          Um, Object Vm, Object du, Object dv, Object u, Object v, Object 
                          a, Object Tc, Object up1, Object up2)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc, up1, up2);
    }


    /// <summary>
    /// Provides the standard 14-input Object interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
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
    public Object[] CreateFiles(int numArgsOut, Object N, Object Mu, Object Mv, Object 
                          Um, Object Vm, Object du, Object dv, Object u, Object v, Object 
                          a, Object Tc, Object up1, Object up2, Object vp1)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc, up1, up2, vp1);
    }


    /// <summary>
    /// Provides the standard 15-input Object interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
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
    public Object[] CreateFiles(int numArgsOut, Object N, Object Mu, Object Mv, Object 
                          Um, Object Vm, Object du, Object dv, Object u, Object v, Object 
                          a, Object Tc, Object up1, Object up2, Object vp1, Object vp2)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc, up1, up2, vp1, vp2);
    }


    /// <summary>
    /// Provides the standard 16-input Object interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
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
    public Object[] CreateFiles(int numArgsOut, Object N, Object Mu, Object Mv, Object 
                          Um, Object Vm, Object du, Object dv, Object u, Object v, Object 
                          a, Object Tc, Object up1, Object up2, Object vp1, Object vp2, 
                          Object Ap1)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc, up1, up2, vp1, vp2, Ap1);
    }


    /// <summary>
    /// Provides the standard 17-input Object interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
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
    public Object[] CreateFiles(int numArgsOut, Object N, Object Mu, Object Mv, Object 
                          Um, Object Vm, Object du, Object dv, Object u, Object v, Object 
                          a, Object Tc, Object up1, Object up2, Object vp1, Object vp2, 
                          Object Ap1, Object Ap2)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc, up1, up2, vp1, vp2, Ap1, Ap2);
    }


    /// <summary>
    /// Provides the standard 18-input Object interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
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
    public Object[] CreateFiles(int numArgsOut, Object N, Object Mu, Object Mv, Object 
                          Um, Object Vm, Object du, Object dv, Object u, Object v, Object 
                          a, Object Tc, Object up1, Object up2, Object vp1, Object vp2, 
                          Object Ap1, Object Ap2, Object gamma)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc, up1, up2, vp1, vp2, Ap1, Ap2, gamma);
    }


    /// <summary>
    /// Provides the standard 19-input Object interface to the CreateFiles MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
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
    public Object[] CreateFiles(int numArgsOut, Object N, Object Mu, Object Mv, Object 
                          Um, Object Vm, Object du, Object dv, Object u, Object v, Object 
                          a, Object Tc, Object up1, Object up2, Object vp1, Object vp2, 
                          Object Ap1, Object Ap2, Object gamma, Object mu)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateFiles", N, Mu, Mv, Um, Vm, du, dv, u, v, a, Tc, up1, up2, vp1, vp2, Ap1, Ap2, gamma, mu);
    }


    /// <summary>
    /// Provides an interface for the CreateFiles function in which the input and output
    /// arguments are specified as an array of Objects.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// --肖袨袪袦袠袪袨袙袗袧袠袝 袦袗小小袠袙袗 袙袝袣孝袪袨袙 袨袚袠袘袗挟些袝袡
    /// 小袠袚袧袗袥袗 袛袥携 袙小袝啸 袚袠袩袨孝袝袟 袩袨 校袚袥校-
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of Object output arguments</param>
    /// <param name= "argsIn">Array of Object input arguments</param>
    /// <param name= "varArgsIn">Array of Object representing variable input
    /// arguments</param>
    ///
    [MATLABSignature("CreateFiles", 19, 1, 0)]
    protected void CreateFiles(int numArgsOut, ref Object[] argsOut, Object[] argsIn, params Object[] varArgsIn)
    {
        mcr.EvaluateFunctionForTypeSafeCall("CreateFiles", numArgsOut, ref argsOut, argsIn, varArgsIn);
    }
    /// <summary>
    /// Provides a single output, 0-input Objectinterface to the CreateL MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object CreateL()
    {
      return mcr.EvaluateFunction("CreateL", new Object[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input Objectinterface to the CreateL MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object CreateL(Object N)
    {
      return mcr.EvaluateFunction("CreateL", N);
    }


    /// <summary>
    /// Provides a single output, 2-input Objectinterface to the CreateL MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object CreateL(Object N, Object Mu)
    {
      return mcr.EvaluateFunction("CreateL", N, Mu);
    }


    /// <summary>
    /// Provides a single output, 3-input Objectinterface to the CreateL MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object CreateL(Object N, Object Mu, Object Mv)
    {
      return mcr.EvaluateFunction("CreateL", N, Mu, Mv);
    }


    /// <summary>
    /// Provides a single output, 4-input Objectinterface to the CreateL MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object CreateL(Object N, Object Mu, Object Mv, Object Um)
    {
      return mcr.EvaluateFunction("CreateL", N, Mu, Mv, Um);
    }


    /// <summary>
    /// Provides a single output, 5-input Objectinterface to the CreateL MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object CreateL(Object N, Object Mu, Object Mv, Object Um, Object Vm)
    {
      return mcr.EvaluateFunction("CreateL", N, Mu, Mv, Um, Vm);
    }


    /// <summary>
    /// Provides a single output, 6-input Objectinterface to the CreateL MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <param name="Um">Input argument #4</param>
    /// <param name="Vm">Input argument #5</param>
    /// <param name="mu">Input argument #6</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object CreateL(Object N, Object Mu, Object Mv, Object Um, Object Vm, Object mu)
    {
      return mcr.EvaluateFunction("CreateL", N, Mu, Mv, Um, Vm, mu);
    }


    /// <summary>
    /// Provides a single output, 7-input Objectinterface to the CreateL MATLAB function.
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
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object CreateL(Object N, Object Mu, Object Mv, Object Um, Object Vm, Object 
                    mu, Object expH)
    {
      return mcr.EvaluateFunction("CreateL", N, Mu, Mv, Um, Vm, mu, expH);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the CreateL MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] CreateL(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateL", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the CreateL MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] CreateL(int numArgsOut, Object N)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateL", N);
    }


    /// <summary>
    /// Provides the standard 2-input Object interface to the CreateL MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] CreateL(int numArgsOut, Object N, Object Mu)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateL", N, Mu);
    }


    /// <summary>
    /// Provides the standard 3-input Object interface to the CreateL MATLAB function.
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
    public Object[] CreateL(int numArgsOut, Object N, Object Mu, Object Mv)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateL", N, Mu, Mv);
    }


    /// <summary>
    /// Provides the standard 4-input Object interface to the CreateL MATLAB function.
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
    public Object[] CreateL(int numArgsOut, Object N, Object Mu, Object Mv, Object Um)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateL", N, Mu, Mv, Um);
    }


    /// <summary>
    /// Provides the standard 5-input Object interface to the CreateL MATLAB function.
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
    public Object[] CreateL(int numArgsOut, Object N, Object Mu, Object Mv, Object Um, 
                      Object Vm)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateL", N, Mu, Mv, Um, Vm);
    }


    /// <summary>
    /// Provides the standard 6-input Object interface to the CreateL MATLAB function.
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
    public Object[] CreateL(int numArgsOut, Object N, Object Mu, Object Mv, Object Um, 
                      Object Vm, Object mu)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateL", N, Mu, Mv, Um, Vm, mu);
    }


    /// <summary>
    /// Provides the standard 7-input Object interface to the CreateL MATLAB function.
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
    public Object[] CreateL(int numArgsOut, Object N, Object Mu, Object Mv, Object Um, 
                      Object Vm, Object mu, Object expH)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreateL", N, Mu, Mv, Um, Vm, mu, expH);
    }


    /// <summary>
    /// Provides an interface for the CreateL function in which the input and output
    /// arguments are specified as an array of Objects.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of Object output arguments</param>
    /// <param name= "argsIn">Array of Object input arguments</param>
    /// <param name= "varArgsIn">Array of Object representing variable input
    /// arguments</param>
    ///
    [MATLABSignature("CreateL", 7, 1, 0)]
    protected void CreateL(int numArgsOut, ref Object[] argsOut, Object[] argsIn, params Object[] varArgsIn)
    {
        mcr.EvaluateFunctionForTypeSafeCall("CreateL", numArgsOut, ref argsOut, argsIn, varArgsIn);
    }
    /// <summary>
    /// Provides a single output, 0-input Objectinterface to the CreatePicture MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// hypothetical signals information
    /// </remarks>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object CreatePicture()
    {
      return mcr.EvaluateFunction("CreatePicture", new Object[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input Objectinterface to the CreatePicture MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// hypothetical signals information
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object CreatePicture(Object N)
    {
      return mcr.EvaluateFunction("CreatePicture", N);
    }


    /// <summary>
    /// Provides a single output, 2-input Objectinterface to the CreatePicture MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// hypothetical signals information
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object CreatePicture(Object N, Object Mu)
    {
      return mcr.EvaluateFunction("CreatePicture", N, Mu);
    }


    /// <summary>
    /// Provides a single output, 3-input Objectinterface to the CreatePicture MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// hypothetical signals information
    /// </remarks>
    /// <param name="N">Input argument #1</param>
    /// <param name="Mu">Input argument #2</param>
    /// <param name="Mv">Input argument #3</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object CreatePicture(Object N, Object Mu, Object Mv)
    {
      return mcr.EvaluateFunction("CreatePicture", N, Mu, Mv);
    }


    /// <summary>
    /// Provides a single output, 4-input Objectinterface to the CreatePicture MATLAB
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
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object CreatePicture(Object N, Object Mu, Object Mv, Object Um)
    {
      return mcr.EvaluateFunction("CreatePicture", N, Mu, Mv, Um);
    }


    /// <summary>
    /// Provides a single output, 5-input Objectinterface to the CreatePicture MATLAB
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
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object CreatePicture(Object N, Object Mu, Object Mv, Object Um, Object Vm)
    {
      return mcr.EvaluateFunction("CreatePicture", N, Mu, Mv, Um, Vm);
    }


    /// <summary>
    /// Provides a single output, 6-input Objectinterface to the CreatePicture MATLAB
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
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object CreatePicture(Object N, Object Mu, Object Mv, Object Um, Object Vm, 
                          Object expH)
    {
      return mcr.EvaluateFunction("CreatePicture", N, Mu, Mv, Um, Vm, expH);
    }


    /// <summary>
    /// Provides a single output, 7-input Objectinterface to the CreatePicture MATLAB
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
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object CreatePicture(Object N, Object Mu, Object Mv, Object Um, Object Vm, 
                          Object expH, Object filecode)
    {
      return mcr.EvaluateFunction("CreatePicture", N, Mu, Mv, Um, Vm, expH, filecode);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the CreatePicture MATLAB
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
    public Object[] CreatePicture(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreatePicture", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the CreatePicture MATLAB
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
    public Object[] CreatePicture(int numArgsOut, Object N)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreatePicture", N);
    }


    /// <summary>
    /// Provides the standard 2-input Object interface to the CreatePicture MATLAB
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
    public Object[] CreatePicture(int numArgsOut, Object N, Object Mu)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreatePicture", N, Mu);
    }


    /// <summary>
    /// Provides the standard 3-input Object interface to the CreatePicture MATLAB
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
    public Object[] CreatePicture(int numArgsOut, Object N, Object Mu, Object Mv)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreatePicture", N, Mu, Mv);
    }


    /// <summary>
    /// Provides the standard 4-input Object interface to the CreatePicture MATLAB
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
    public Object[] CreatePicture(int numArgsOut, Object N, Object Mu, Object Mv, Object 
                            Um)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreatePicture", N, Mu, Mv, Um);
    }


    /// <summary>
    /// Provides the standard 5-input Object interface to the CreatePicture MATLAB
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
    public Object[] CreatePicture(int numArgsOut, Object N, Object Mu, Object Mv, Object 
                            Um, Object Vm)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreatePicture", N, Mu, Mv, Um, Vm);
    }


    /// <summary>
    /// Provides the standard 6-input Object interface to the CreatePicture MATLAB
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
    public Object[] CreatePicture(int numArgsOut, Object N, Object Mu, Object Mv, Object 
                            Um, Object Vm, Object expH)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreatePicture", N, Mu, Mv, Um, Vm, expH);
    }


    /// <summary>
    /// Provides the standard 7-input Object interface to the CreatePicture MATLAB
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
    public Object[] CreatePicture(int numArgsOut, Object N, Object Mu, Object Mv, Object 
                            Um, Object Vm, Object expH, Object filecode)
    {
      return mcr.EvaluateFunction(numArgsOut, "CreatePicture", N, Mu, Mv, Um, Vm, expH, filecode);
    }


    /// <summary>
    /// Provides an interface for the CreatePicture function in which the input and
    /// output
    /// arguments are specified as an array of Objects.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// hypothetical signals information
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of Object output arguments</param>
    /// <param name= "argsIn">Array of Object input arguments</param>
    /// <param name= "varArgsIn">Array of Object representing variable input
    /// arguments</param>
    ///
    [MATLABSignature("CreatePicture", 7, 1, 0)]
    protected void CreatePicture(int numArgsOut, ref Object[] argsOut, Object[] argsIn, params Object[] varArgsIn)
    {
        mcr.EvaluateFunctionForTypeSafeCall("CreatePicture", numArgsOut, ref argsOut, argsIn, varArgsIn);
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
