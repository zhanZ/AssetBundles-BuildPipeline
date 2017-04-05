﻿using System;
using System.Collections.Generic;
using System.Text;
using UnityEditor.Build.Utilities;
using UnityEditor.Experimental.Build.AssetBundle;

namespace UnityEditor.Build.AssetBundle.DataConverters
{
    public class AddressableAssetPacker : IDataConverter<BuildInput.AddressableAsset[], BuildInput>
    {
        public int GetInputHash(BuildInput.AddressableAsset[] input)
        {
            return input.GetHashCode();
        }

        public bool Convert(BuildInput.AddressableAsset[] input, out BuildInput output)
        {
            output = new BuildInput();
            if (input.IsNullOrEmpty())
            {
                BuildLogger.LogError("Unable to continue packing. Input is null or empty!");
                return false;
            }

            output.definitions = new BuildInput.Definition[input.Length];
            for (var index = 0; index < input.Length; index++)
            {
                output.definitions[index].assetBundleName = input[index].asset.ToString();
                output.definitions[index].explicitAssets = new[] { input[index] };
            }
            return true;
        }
    }
}
