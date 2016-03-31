﻿using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using SKBKontur.Infrastructure.Common;

namespace SKBKontur.Treller.WebApplication.Implementation.Infrastructure
{
    public class FileSystemHandler : IFileSystemHandler
    {
        private readonly string appPathRoot;

        public FileSystemHandler()
        {
            appPathRoot = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(HttpRuntime.AppDomainAppPath)),"TrellerData");
        }

        public TEntity FindSafeInJsonUtf8File<TEntity>(string fileName)
        {
            var result = FindSafeInJsonUtf8File(fileName, typeof (TEntity));

            return result is TEntity
                    ? (TEntity) result
                    : default(TEntity);
        }

        public object FindSafeInJsonUtf8File(string fileName, Type type)
        {
            var fullName = GetFullPath(fileName);

            if (!File.Exists(fullName))
            {
                return null;
            }

            try
            {
                var fileText = File.ReadAllText(fullName, Encoding.UTF8);
                return JsonConvert.DeserializeObject(fileText, type);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void WriteInJsonUtf8File<TEntity>(string fileName, TEntity entity)
        {
            var fullName = GetFullPath(fileName);
            var serializedEntity = JsonConvert.SerializeObject(entity);
            var stopwatch = Stopwatch.StartNew();

            while (!RecurcyWrite(fullName, serializedEntity))
            {
                if (stopwatch.Elapsed.TotalSeconds > 5)
                {
                    stopwatch.Stop();
                    throw new Exception(string.Format("Can't write file {0} for 5 seconds", fullName));
                }
            }
        }

        private static bool RecurcyWrite(string fullName, string serializedEntity)
        {
            try
            {
                File.WriteAllText(fullName, serializedEntity, Encoding.UTF8);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private string GetFullPath(string fileName)
        {
            return Path.Combine(appPathRoot, fileName);
        }
    }
}