﻿using System;

namespace CSharpLibraries.Interpreters{
  internal static class InterpretersExceptions{
    public class SyntaxException : Exception{
      public SyntaxException(string s) : base(s){
      }
    }

    public class RuntimeWarning : Exception{
      public object ReturnValue;

      public RuntimeWarning(string m) : base(m){
      }
    }

    public class ArgumentsCountException : Exception{
      public ArgumentsCountException(string s) : base(s){
      }
    }

    public class LookUpException : Exception{
      public LookUpException(string s) : base(s){
      }
    }

    public class TypeException : Exception{
      public TypeException(string s) : base(s){
      }
    }
  }
}