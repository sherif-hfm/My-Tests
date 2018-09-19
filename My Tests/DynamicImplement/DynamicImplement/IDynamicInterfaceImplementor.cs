﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicImplement
{
    public interface IDynamicInterfaceImplementor
    {
        Type CreateType(Type interfaceType, Type dynamicProxyBaseType);
    }
}