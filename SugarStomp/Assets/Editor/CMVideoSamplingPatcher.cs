//-------------------------------------------------------------
//
//  CMVideoSamplingPatcher
//  Copyright © 2014 Egomotion Limited
//
//  When using Xcode 6 and Unity 4.3.4 or earlier, iOS builds
//  fail due to a missing include in CMVideoSampling.mm.
//  
//  This PostProcessBuild script adds the glext.h header
//  to the CMVideoSampling.mm file if it is missing.
//
//-------------------------------------------------------------

using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class CMVideoSamplingPatcher : BuildPatchEditor
{
  const string _fileName     = "CMVideoSampling.mm";
  const string _patchLine    = "#include <OpenGLES/ES2/glext.h>";
  const string _locationLine = "#include <OpenGLES/ES2/gl.h>";

  [PostProcessBuild]
  public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject) {
    if (target != BuildTarget.iPhone) {
      return;
    }
		
    BuildPatchEditor.Patch(target, pathToBuiltProject, _fileName, _patchLine, _locationLine);
  }
}
