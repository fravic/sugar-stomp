//-------------------------------------------------------------
// Code modified from CMVideoSamplingPatcher
// Copyright © 2014 Egomotion Limited
//-------------------------------------------------------------

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class BuildPatchEditor {
  protected static void Patch(BuildTarget target, string pathToBuiltProject, string fileName, string patchCode, string locationLine)
  {
    var dirInfo = Directory.GetFiles(pathToBuiltProject, fileName, SearchOption.AllDirectories);    

    if (dirInfo == null || dirInfo.Length <= 0) {
      Debug.LogError("Could not find " + fileName);
      return;
    }

    var cmSamplingPath = dirInfo[0];
    var content = new List<string>(File.ReadAllLines(cmSamplingPath));

    int index = 0;
    var doPatch = true;

    for (int ii = 0; ii < content.Count; ++ii) {
	var line = content[ii];

	if (line.Contains(patchCode)) {
	  doPatch = false;
	  break;
	}
	if (line.Contains(locationLine)) {
	  index = ii+1;
	}
    }

    if (doPatch) {
	Debug.Log("Patching " + fileName);
	content.Insert(index, patchCode);
	File.WriteAllLines(cmSamplingPath, content.ToArray());
    } else {
      Debug.Log(fileName + " patch already applied. Skipping.");
    }
  }
}
