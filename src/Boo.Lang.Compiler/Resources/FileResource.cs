﻿#region license
// boo - an extensible programming language for the CLI
// Copyright (C) 2004 Rodrigo Barreto de Oliveira
//
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
// 
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
// Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
// 
// Contact Information
//
// mailto:rbo@acm.org
#endregion

namespace Boo.Lang.Compiler.Resources
{
	using System;
	using System.Resources;
	using System.Collections;
	using Boo.Lang.Compiler;
	
	public class FileResource : ICompilerResource
	{
		string _fname;
		
		public FileResource(string fname)
		{
			if (null == fname)
			{
				throw new ArgumentNullException("fname");
			}
			_fname = fname;
		}
		
		public string Name
		{
			get
			{
				return System.IO.Path.GetFileName(_fname);
			}
		}
		
		public string Description
		{
			get
			{
				return null;
			}
		}
		
		public void WriteResources(System.Resources.IResourceWriter writer)
		{
			using (ResourceReader reader = new ResourceReader(_fname))
			{
				IDictionaryEnumerator e = reader.GetEnumerator();
				while (e.MoveNext())
				{
					writer.AddResource((string)e.Key, e.Value);
				}
			}
		}	
	}
}
