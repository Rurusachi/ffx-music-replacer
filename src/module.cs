// SPDX-License-Identifier: MIT

using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using MusicReplacer.GUI;

using FhXCall = Fahrenheit.FFX.FhCall;

namespace MusicReplacer;

[FhLoad(FhGameId.FFX)]
public unsafe class MusicReplacerModule : FhModule {
    const string game = "FFX.exe";

    public override bool init(FhModContext mod_context, FileStream global_state_file) {

        return true;
    }


    public override void render_imgui() {
        MusicReplacerGUI.render();
    }

    public override void load_local_state(FileStream? local_state_file, FhLocalStateInfo local_state_info) {
    }
    public override void save_local_state(FileStream  local_state_file) {
    }
}
