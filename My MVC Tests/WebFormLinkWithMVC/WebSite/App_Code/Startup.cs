﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Startup
/// </summary>
public class Startup
{
	public Startup()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static void StartupMvc()
    {
        MVCApp.Startup.StartupMvc();
    }
}