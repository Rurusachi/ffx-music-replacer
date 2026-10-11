// SPDX-License-Identifier: MIT

using Hexa.NET.ImGui;

namespace MusicReplacer.GUI;

public unsafe static class MusicReplacerGUI {

    public static void render() {
#if DEBUG
        renderDebug();
#endif
    }

    public static void renderDebug() {
    }
}
