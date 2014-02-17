﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Document
{
	public static class FormattingExtensionMethod
	{

		public static string ToYesNo(this bool input)
		{
			if (input)
			{
				return "Yes";
			}

			return "No";
		}


        /// <summary>
        /// For a given foreign key get the column names as array of string
        /// </summary>
        /// <param name="fk"></param>
        /// <returns></returns>
        public static string[] GetForeignKeyParentColumnNames(this ForeignKey fk)
        {
          return (
                from fkc in fk.ForeignKeyColumns
                orderby fkc.ConstraintColumnId
                select fkc.ParentColumnName
                ).ToArray();

        }

        public static string[] GetForeignKeyReferenceColumnNames(this ForeignKey fk)
        {
            return (
                from fkc in fk.ForeignKeyColumns
                orderby fkc.ConstraintColumnId
                select fkc.ReferenceColumnName
                ).ToArray();
        }

        /// <summary>
        /// Create reader friendly text for display of a functon return value
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string GetReturnTypeDisplayText(this ScalarFunction func)
        {
            var dispText = new StringBuilder();

            if (!String.IsNullOrWhiteSpace(func.ReturnDataType))
            {
                dispText.Append(func.ReturnDataType);
            }

            //has numeric precision and scale
            if (func.ReturnTypePrecision.HasValue && func.ReturnTypeScale.HasValue)
            {
                dispText.Append(String.Format("({0},{1})", func.ReturnTypePrecision.Value, func.ReturnTypeScale.Value));
            }
            else
            {
                if (func.ReturnTypeMaximumLength.HasValue && func.ReturnTypeMaximumLength != -1)
                {
                    dispText.Append(String.Format("({0})", func.ReturnTypeMaximumLength.Value));
                }
            }

            return dispText.ToString();

        }

	}
}
