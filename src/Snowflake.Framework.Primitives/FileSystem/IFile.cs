﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Snowflake.Model.Records.File;

namespace Snowflake.Filesystem
{
    public interface IFile
    {
        string Name { get; }
        long Length { get; }
        IDirectory ParentDirectory { get; }
        Stream OpenStream();
        Stream OpenStream(FileAccess rw);
        void Rename(string newName);
        void Delete();

        ///
        Guid FileGuid { get; }

        bool Created { get; }

        /// <summary>
        /// Returns the real file path of this file.
        /// 
        /// This method is obsolete because it is unsafe to use,
        /// without going through the interface methods of 
        /// <see cref="IFile"/>, there is no guarantee that the parent
        /// <see cref="IDirectory"/> instance will remain consistent.
        /// 
        /// Restrict usage to read-only unless absolutely necessary.
        /// </summary>
        /// <returns>The real file path of the file.</returns>
        [Obsolete("Avoid accessing the underlying file path, and use the object methods instead.")]
        FileInfo GetFilePath();

        /// <summary>
        /// The path of this file, relative to the root of the directory provider.
        /// </summary>
        string RootedPath { get; }
    }
}
