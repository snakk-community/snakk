//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using Snakk.API.PluginFramework;
using System;
using System.Collections.Generic;
using System.IO;
using Weikio.PluginFramework.Abstractions;
using Weikio.PluginFramework.Catalogs;
using Weikio.PluginFramework.TypeFinding;

namespace Snakk.API
{
    public class PluginRegistry
    {
		private static readonly DirectoryInfo[] _pluginPaths = new[]
		{
			new DirectoryInfo("./plugins")
		};

		private static readonly Type _pluginBaseType = typeof(IPlugin);

		private static readonly Type[] _pluginTypes = new[]
		{
			typeof(PluginFramework.Hooks.Routes.Channel.Thread.List.Services.Get.IService),
			typeof(PluginFramework.Hooks.Routes.Channel.Services.Get.IService),
			typeof(PluginFramework.Hooks.Routes.Thread.Services.Get.IService),
			typeof(PluginFramework.Hooks.Routes.Comment.Services.Get.IService),
		};

		public static void LoadPlugins()
		{
			var allCatalogs = new CompositePluginCatalog();

			foreach (DirectoryInfo pluginPath in _pluginPaths)
			{
				foreach (Type type in _pluginTypes)
				{
					IPluginCatalog catalog = LoadPluginsOfType(pluginPath, type);
					allCatalogs.AddCatalog(catalog);
				}
			}

			// initialize all catalogs syncronously
			allCatalogs.Initialize().Wait();

			//var plugins = allCatalogs.GetPlugins();

			//return plugins.Count;
		}

		private static IPluginCatalog LoadPluginsOfType(DirectoryInfo pluginDirectory, Type pluginType)
		{
			TypeFinderCriteria? pluginCriteria = TypeFinderCriteriaBuilder.Create()
				.Implements(_pluginBaseType)
				.Implements(pluginType)
				.Build();

			if (pluginCriteria == null)
			{
				throw new InvalidOperationException("Failed to build plugin search criteria.");
			}

			FolderPluginCatalogOptions options = new()
			{
				IncludeSubfolders = false,
				TypeFinderOptions = new TypeFinderOptions()
				{
					TypeFinderCriterias = new List<TypeFinderCriteria> { pluginCriteria }
				}
			};

			return new FolderPluginCatalog(pluginDirectory.FullName, options);
		}
	}
}
