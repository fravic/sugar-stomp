//--------------------------------------------------------------------------------------
// Fix for XCode 6
//   Undefined symbols for architecture i386: "_clock$UNIX2003"
// http://forum.unity3d.com/threads/ios8-xcode6-compatibility.249533/page-2#post-1769753
//--------------------------------------------------------------------------------------

using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class PatchClockAlias : BuildPatchEditor {
  const string _fileName     = "main.mm";
  const string _locationLine = "#include \"RegisterMonoModules.h\"";

  [PostProcessBuild]
  public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject) {
    if (target != BuildTarget.iPhone) {
      return;
    }

    string patchCode  =
      "#include <time.h>\n" +
      "extern \"C\" {\n" + 
      "  clock_t\n" +
      "  clock$UNIX2003(void) {\n" +
      "    return clock();\n" +
      "  }\n" +
      "}";
    patchCode.Replace("\n", System.Environment.NewLine);
		
    BuildPatchEditor.Patch(target, pathToBuiltProject, _fileName, patchCode, _locationLine);
  }
}

