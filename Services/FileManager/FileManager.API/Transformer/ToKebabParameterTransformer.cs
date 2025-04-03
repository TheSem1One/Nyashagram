﻿using System.Text.RegularExpressions;

namespace FileManager.API.Transformer
{
    public class ToKebabParameterTransformer : IOutboundParameterTransformer
    {
        public string TransformOutbound(object? value) => value != null
            ? Regex.Replace(value.ToString() ?? string.Empty, "([a-z])([A-Z])", "$1-$2").ToLower()
            : string.Empty;
    }
}
