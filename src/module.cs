// SPDX-License-Identifier: MIT

using Fahrenheit;
using MusicReplacer.GUI;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using FhXCall = Fahrenheit.FFX.FhCall;

namespace MusicReplacer;

[FhLoad(FhGameId.FFX)]
public unsafe class MusicReplacerModule : FhModule {
    const string game = "FFX.exe";


    [StructLayout(LayoutKind.Sequential, Size = 0x3C)]
    public struct FmodMusic_Event {
        public nint  _event;
        public int   __0x4;
        public int   __0x8;
        public int   __0xc;
        public int   __0x10;
        public int   __0x14;
        public int   __0x18;
        public int   __0x1c;
        public int   __0x20;
        public int   __0x24;
        public int   __0x28;
        public int   __0x2c;
        public int   __0x30;
        public float __0x34;
        public float __0x38;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x34)]
    public struct FmodMusic {
        [FieldOffset(0x00)] public nint p_event_group_arranged;
        [FieldOffset(0x04)] public nint p_event_group_original;
        [FieldOffset(0x08)] public nint p_event_project_arranged;
        [FieldOffset(0x0C)] public nint p_event_project_original;
        [FieldOffset(0x10)] public FmodMusic_Event* p_events;

        [FieldOffset(0x18)] public int __0x18;
        [FieldOffset(0x1C)] public int __0x1c;
        [FieldOffset(0x20)] public int __0x20;
        [FieldOffset(0x24)] public int __0x24;

        [FieldOffset(0x28)] public int __0x28;
        [FieldOffset(0x2C)] public int soundtrack_version;
    }

    public struct FmodShout {
        public  nint p_sound;
        private uint __0x4;
        private uint __0x8;
        public  uint num_sub_sounds;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x34)]
    public struct FmodVoice {
        [FieldOffset(0x04)] public byte language;
        [FieldOffset(0x1C)] public nint p_event_group_voice_btl;
        [FieldOffset(0x20)] public nint p_event_project_voice_btl;
        [FieldOffset(0x24)] public nint p_voice_id_mapper;
        [FieldOffset(0x28)] public nint p_voice_fev_mapper;


        [FieldOffset(0x84)] public FmodShout* p_fmod_shout;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public struct FfxFmod {
        [FieldOffset(0x04)] public nint       p_event_system;
        [FieldOffset(0x08)] public nint       p_system;
        [FieldOffset(0x0C)] public FmodMusic* p_fmod_music;
        [FieldOffset(0x10)] public FmodVoice* p_fmod_voice;
    }

    public enum FMOD_RESULT : int {
        FMOD_OK = 0,

        FMOD_ERR_INVALID_FLOAT = 0x23,
        FMOD_ERR_INVALID_HANDLE = 0x24,
        FMOD_ERR_INVALID_PARAM = 0x25,
        FMOD_ERR_INVALID_POSITION = 0x26,
        FMOD_ERR_INVALID_SPEAKER = 0x27,
        FMOD_ERR_INVALID_SYNCPOINT = 0x28,

        FMOD_ERR_MAXAUDIBLE = 0x2a,
        FMOD_ERR_MEMORY = 0x2b,
        FMOD_ERR_MEMORY_CANTPOINT = 0x2c,

        FMOD_ERR_EVENT_MISMATCH = 0x57,
    }


    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void d_FUN_00308d40(nint p_event_system, byte* path, int* param_3, int* param_4);
    private FhCallHandle<d_FUN_00308d40> FUN_00308d40
        => new(new FhCallLocation("FFX.exe", 0x308d40));


    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void d_FUN_00306820(FfxFmod* _this);
    private FhCallHandle<d_FUN_00306820> FUN_00306820
        => new(new FhCallLocation("FFX.exe", 0x306820));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_FUN_00308be0(int event_id);
    private FhCallHandle<d_FUN_00308be0> FUN_00308be0
        => new(new FhCallLocation("FFX.exe", 0x00308be0));




    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void d_FmodMusic_read(FmodMusic* _this, int event_id, nint event_system);
    private FhCallHandle<d_FmodMusic_read> FmodMusic_read
        => new(new FhCallLocation("FFX.exe", 0x309080));

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void d_FmodMusic_start(FmodMusic* _this, int event_id);
    private FhCallHandle<d_FmodMusic_start> FmodMusic_start
        => new(new FhCallLocation("FFX.exe", 0x3096f0));

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void d_FmodMusic_stop(FmodMusic* _this, int event_id);
    private FhCallHandle<d_FmodMusic_stop> FmodMusic_stop
        => new(new FhCallLocation("FFX.exe", 0x3099a0));

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void d_FmodMusic_clear(FmodMusic* _this, int event_id);
    private FhCallHandle<d_FmodMusic_clear> FmodMusic_clear
        => new(new FhCallLocation("FFX.exe", 0x308720));



    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate FMOD_RESULT d_FUN_00307a50(nint _event, int event_type, void* param_1, void* param_2, void* userdata);
    private FhCallHandle<d_FUN_00307a50> FUN_00307a50
        => new(new FhCallLocation("FFX.exe", 0x307a50));



    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate FMOD_RESULT d_FMOD_System_CreateSound(nint _this, nint path, uint mode, nint exinfo, nint* out_sound);
    public static FhCallHandle<d_FMOD_System_CreateSound> FMOD_System_CreateSound
        => new(new FhCallLocation("fmodex.dll", "FMOD_System_CreateSound"));
    //=> new(new FhCallLocation("fmodex.dll", "?createSound@System@FMOD@@QAG?AW4FMOD_RESULT@@PBDIPAUFMOD_CREATESOUNDEXINFO@@PAPAVSound@2@@Z"));

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate FMOD_RESULT d_FMOD_System_PlaySound(nint _this, int channel_index, nint p_sound, bool paused, nint* out_channel);
    public static FhCallHandle<d_FMOD_System_PlaySound> FMOD_System_PlaySound
        => new(new FhCallLocation("fmodex.dll", "FMOD_System_PlaySound"));
    //=> new(new FhCallLocation("fmodex.dll", "?playSound@System@FMOD@@QAG?AW4FMOD_RESULT@@W4FMOD_CHANNELINDEX@@PAVSound@2@_NPAPAVChannel@2@@Z"));

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate FMOD_RESULT d_FMOD_System_playSound_cpp(nint _this, int channel_index, nint p_sound, bool paused, nint* out_channel);
    public static FhCallHandle<d_FMOD_System_playSound_cpp> FMOD_System_playSound_cpp
        => new(new FhCallLocation("fmodex.dll", "?playSound@System@FMOD@@QAG?AW4FMOD_RESULT@@W4FMOD_CHANNELINDEX@@PAVSound@2@_NPAPAVChannel@2@@Z"));

    //[UnmanagedFunctionPointer(CallingConvention.StdCall)]
    //public delegate FMOD_RESULT d_FMOD_Sound_setUserData(nint _this, void* userdata);
    //public static FhCallHandle<d_FMOD_Sound_setUserData> FMOD_Sound_setUserData
    //    => new(new FhCallLocation("fmodex.dll", "?setUserData@Sound@FMOD@@QAG?AW4FMOD_RESULT@@PAX@Z"));


    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate FMOD_RESULT d_FMOD_Sound_SetMode(nint _this, int mode);
    public static FhCallHandle<d_FMOD_Sound_SetMode> FMOD_Sound_SetMode
        => new(new FhCallLocation("fmodex.dll", "FMOD_Sound_SetMode"));

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate FMOD_RESULT d_FMOD_Sound_Release(nint _this);
    public static FhCallHandle<d_FMOD_Sound_Release> FMOD_Sound_Release
        => new(new FhCallLocation("fmodex.dll", "FMOD_Sound_Release"));


    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate FMOD_RESULT d_FMOD_Channel_SetPaused(nint _this, bool isPaused);
    public static FhCallHandle<d_FMOD_Channel_SetPaused> FMOD_Channel_SetPaused
        => new(new FhCallLocation("fmodex.dll", "FMOD_Channel_SetPaused"));
    //=> new(new FhCallLocation("fmodex.dll", "?setPaused@Channel@FMOD@@QAG?AW4FMOD_RESULT@@_N@Z"));

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate FMOD_RESULT d_FMOD_Channel_Stop(nint _this);
    public static FhCallHandle<d_FMOD_Channel_Stop> FMOD_Channel_Stop
        => new(new FhCallLocation("fmodex.dll", "FMOD_Channel_Stop"));
    //=> new(new FhCallLocation("fmodex.dll", "?stop@Channel@FMOD@@QAG?AW4FMOD_RESULT@@XZ"));




    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate FMOD_RESULT d_FMOD_Channel_SetChannelGroup(nint _this, nint channel_group);
    public static FhCallHandle<d_FMOD_Channel_SetChannelGroup> FMOD_Channel_SetChannelGroup
        => new(new FhCallLocation("fmodex.dll", "FMOD_Channel_SetChannelGroup"));
    //=> new(new FhCallLocation("fmodex.dll", "?setChannelGroup@Channel@FMOD@@QAG?AW4FMOD_RESULT@@PAVChannelGroup@2@@Z"));





    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate FMOD_RESULT d_FMOD_ChannelI_validate(nint _channel, nint* out_p_channeli);
    public static FhCallHandle<d_FMOD_ChannelI_validate> FMOD_ChannelI_validate
        => new(new FhCallLocation("fmodex.dll", "?validate@ChannelI@FMOD@@SG?AW4FMOD_RESULT@@PAVChannel@2@PAPAV12@@Z"));



    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate FMOD_RESULT d_FMOD_ChannelGroup_GetNumChannels(nint _this, int* out_num);
    public static FhCallHandle<d_FMOD_ChannelGroup_GetNumChannels> FMOD_ChannelGroup_GetNumChannels
        => new(new FhCallLocation("fmodex.dll", "FMOD_ChannelGroup_GetNumChannels"));
    //=> new(new FhCallLocation("fmodex.dll", "?getNumChannels@ChannelGroup@FMOD@@QAG?AW4FMOD_RESULT@@PAH@Z"));


    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate FMOD_RESULT d_FMOD_ChannelGroup_GetChannel(nint _this, int channel_id, nint* out_channel);
    public static FhCallHandle<d_FMOD_ChannelGroup_GetChannel> FMOD_ChannelGroup_GetChannel
        => new(new FhCallLocation("fmodex.dll", "FMOD_ChannelGroup_GetChannel"));
    //=> new(new FhCallLocation("fmodex.dll", "?getChannel@ChannelGroup@FMOD@@QAG?AW4FMOD_RESULT@@HPAPAVChannel@2@@Z"));

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate FMOD_RESULT d_FMOD_EventGroup_GetNumEvents(nint _this, int* out_num);
    public static FhCallHandle<d_FMOD_EventGroup_GetNumEvents> FMOD_EventGroup_GetNumEvents
        => new(new FhCallLocation("fmod_event.dll", "FMOD_EventGroup_GetNumEvents"));

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate FMOD_RESULT d_FMOD_EventGroup_GetEventByIndex(nint _this, int event_id, int mode, nint* out_event);
    public static FhCallHandle<d_FMOD_EventGroup_GetEventByIndex> FMOD_EventGroup_GetEventByIndex
        => new(new FhCallLocation("fmod_event.dll", "FMOD_EventGroup_GetEventByIndex"));


    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate FMOD_RESULT d_FMOD_Event_validate(nint _event, nint* out_p_eventi);
    public static FhCallHandle<d_FMOD_Event_validate> FMOD_Event_validate
        => new(new FhCallLocation("fmod_event.dll", 0x17130));


    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate FMOD_RESULT d_FMOD_Event_GetChannelGroup(nint _event, nint* out_channel_group);
    public static FhCallHandle<d_FMOD_Event_GetChannelGroup> FMOD_Event_GetChannelGroup
        => new(new FhCallLocation("fmod_event.dll", "FMOD_Event_GetChannelGroup"));


    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate FMOD_RESULT d_FMOD_Event_GetState(nint _event, nint* out_state);
    public static FhCallHandle<d_FMOD_Event_GetState> FMOD_Event_GetState
        => new(new FhCallLocation("fmod_event.dll", "FMOD_Event_GetState"));
    //=> new(new FhCallLocation("fmod_event.dll", "?getState@Event@FMOD@@QAG?AW4FMOD_RESULT@@PAI@Z"));

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate FMOD_RESULT d_FMOD_Event_getPropertyByIndex(nint _event, int index, void* out_value, int _instance);
    public static FhCallHandle<d_FMOD_Event_getPropertyByIndex> FMOD_Event_getPropertyByIndex
        => new(new FhCallLocation("fmod_event.dll", "FMOD_Event_GetPropertyByIndex"));



    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void d_FMOD_EventI_call_callback(nint p_eventi, int event_type, void* param_1, void* param_2);
    public static FhCallHandle<d_FMOD_EventI_call_callback> FMOD_EventI_call_callback
        => new(new FhCallLocation("fmod_event.dll", 0x13b90));

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void d_FMOD_EventI_FUN_1001a9c0(nint _this, nint param_1, int param_2, int* param_3);
    public static FhCallHandle<d_FMOD_EventI_FUN_1001a9c0> FMOD_EventI_FUN_1001a9c0
        => new(new FhCallLocation("fmod_event.dll", 0x1a9c0));

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate FMOD_RESULT d_FMOD_FUN_1002bd70(nint _this, uint param_1, byte* param_2);
    public static FhCallHandle<d_FMOD_FUN_1002bd70> FMOD_FUN_1002bd70
        => new(new FhCallLocation("fmod_event.dll", 0x2bd70));

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate FMOD_RESULT d_FMOD_FUN_10039bc0(nint _this, uint param_1, nint* out_p_sound);
    public static FhCallHandle<d_FMOD_FUN_10039bc0> FMOD_FUN_10039bc0
        => new(new FhCallLocation("fmod_event.dll", 0x39bc0));



    private Dictionary<string, List<nint>> event_to_sound = [];

    public FhModContext mod_context;
    public override bool init(FhModContext mod_context, FileStream global_state_file) {
        this.mod_context = mod_context;

        return FUN_00306820.hook(this, h_FUN_00306820)
            && FMOD_EventI_FUN_1001a9c0.hook(this, h_FMOD_EventI_FUN_1001a9c0)
            && FMOD_FUN_1002bd70.hook(this, h_FMOD_FUN_1002bd70)
            && FMOD_FUN_10039bc0.hook(this, h_FMOD_FUN_10039bc0);
    }


    public override void render_imgui() {
        MusicReplacerGUI.render();
    }

    public override void load_local_state(FileStream? local_state_file, FhLocalStateInfo local_state_info) {
    }
    public override void save_local_state(FileStream  local_state_file) {
    }


    bool register_replacement(string event_name, FileInfo file, bool clear_previous = false) {
        if (p_ffx_fmod is null) return false; // Registering too early

        nint path = Marshal.StringToHGlobalAnsi(file.FullName);
        nint p_sound;
        FMOD_RESULT result = FMOD_System_CreateSound.fnptr!(p_ffx_fmod->p_system, path, 0x200, 0x0, &p_sound);
        _logger.Info($"createSound: p_system={p_ffx_fmod->p_system}, result={result}, p_sound={p_sound}");
        Marshal.FreeHGlobal(path);

        if (result == FMOD_RESULT.FMOD_OK) {
            if (event_to_sound.TryGetValue(event_name, out List<nint>? p_registered_sounds)) {
                if (clear_previous) {
                    _logger.Info($"Overriding previously registered replacements for \"{event_name}\" (FMOD_Sound_Release={result})");
                    foreach (nint sound in p_registered_sounds) {
                        result = FMOD_Sound_Release.fnptr!(sound);
                    }
                    p_registered_sounds.Clear();
                }
            } else {
                event_to_sound[event_name] = [];
            }
            event_to_sound[event_name].Add(p_sound);
            _logger.Info($"Registered event replacement: \"{event_name}\" -> \"{file.FullName}\"");
            return true;
        }
        return false;
    }


    FfxFmod* p_ffx_fmod;
    private nint? current_event = null;
    private bool replaced_sound = false;

    // FfxFmod initialization
    void h_FUN_00306820(FfxFmod* _this) {
        FUN_00306820.chain_from(h_FUN_00306820).fnptr!(_this);
        p_ffx_fmod = _this;

        foreach (DirectoryInfo dir in mod_context.Paths.ResourcesDir.GetDirectories()) {
            string name = dir.Name.ToLowerInvariant();
            if (event_names.Contains(name)) {
                foreach (FileInfo file in dir.GetFiles()) {
                    register_replacement(name, file);
                }
            }
        }

        //foreach (FileInfo file in mod_context.Paths.ResourcesDir.GetFiles()) {
        //    string name = file.Name.ToLowerInvariant();
        //    name = name[..name.LastIndexOf('.')];
        //    if (event_names.Contains(name)) {
        //        register_replacement(name, file);
        //    }
        //}
    }

    void h_FMOD_EventI_FUN_1001a9c0(nint _this, nint param_1, int param_2, int* param_3) {
        current_event = _this;

        FMOD_EventI_FUN_1001a9c0.chain_from(h_FMOD_EventI_FUN_1001a9c0).fnptr!(_this, param_1, param_2, param_3);

        current_event = null;
    }

    FMOD_RESULT h_FMOD_FUN_1002bd70(nint _this, uint param_1, byte* param_2) {
        FMOD_RESULT result;

        result = FMOD_FUN_1002bd70.chain_from(h_FMOD_FUN_1002bd70).fnptr!(_this, param_1, param_2);

        if (replaced_sound) {
            // FMOD_ERR_EVENT_MISMATCH is expected due to the replacement sound not having the same number of subsounds as the original
            if (result != FMOD_RESULT.FMOD_ERR_EVENT_MISMATCH) {
                _logger.Warning($"Unexpected result: {result}");
            }

            nint p_sound = *(nint*)((int)_this + 0x28);

            // Set looping or non-looping
            result = FMOD_Sound_SetMode.fnptr!(p_sound, 2 - ((*(uint*)((int)_this + 0x24) & 4) != 0 ? 1 : 0));

            // Call callback if sound was created and callback is registered
            nint _event = *(nint*)((int)_this + 0x20);
            if ((p_sound != 0) && (*(nint*)(_event + 0x84) != 0x0)) {

                int __0x14 = *(int*)(_this + 0x14);
                int __0xc = *(int*)(__0x14 + 0xc);
                void* _name = *(void**)(__0xc + 0x10);

                FMOD_EventI_call_callback.fnptr!(_event,
                                          8,
                                          _name,
                                          (void*)p_sound);
            }
            // Unknown
            *(ushort*)((int)_this + 0x3e) = *(ushort*)((int)_this + 0x3c);
            *(ushort*)((int)_this + 0x3c) = 0xffff;

            result = FMOD_RESULT.FMOD_OK;
            replaced_sound = false;
        }

        return result;
    }

    FMOD_RESULT h_FMOD_FUN_10039bc0(nint _this, uint param_1, nint* out_p_sound) {
        FMOD_RESULT result;

        if (current_event is not null) {
            _logger.Info($"event=0x{*(nint*)(current_event + 0x18):X8}");
            nint p_event_name;
            result = FMOD_Event_getPropertyByIndex.fnptr!(*(nint*)(current_event + 0x18), 0, &p_event_name, 1); // Property 0 = name
            _logger.Info($"getPropertyByIndex: result={result}, p_event_name=0x{p_event_name:X8}");

            if (result == FMOD_RESULT.FMOD_OK) {
                string? event_name = Marshal.PtrToStringAnsi(p_event_name);
                if (event_name is not null) {
                    _logger.Info($"event 0x{current_event:X2}: name={event_name}");

                    if (event_to_sound.TryGetValue(event_name, out List<nint>? sounds)) {
                        int index = 0;
                        if (sounds.Count > 1) {
                            index = Random.Shared.Next(sounds.Count);
                        }

                        *out_p_sound = sounds[index];
                        replaced_sound = true;
                        return FMOD_RESULT.FMOD_OK;
                    }
                }
            }
        }

        result = FMOD_FUN_10039bc0.chain_from(h_FMOD_FUN_10039bc0).fnptr!(_this, param_1, out_p_sound);
        return result;
    }



    public List<string> event_names = [
        "1_02_zanarkand",
        "1_03_prelude",
        "1_04_tidus_s_theme",
        "1_05_otherworld",
        "1_06_run",
        "1_08_creep",
        "1_09_battle_theme",
        "1_10_victory_fanfare",
        "1_11_game_over_oneshot",
        "1_12_out_of_the_frying_pan",
        "1_13_leap_in_the_dark",
        "1_14_underwater_ruins",
        "1_15_oui_are_al_bhed",
        "1_16_enemy_attack",
        "1_17_the_blitzers",
        "1_18_besaid",
        "1_19_spira_unplugged",
        "1_20_hum_of_the_fayth",
        "1_21_phantoms",
        "1_22_the_trials",
        "1_23_hymn_valefor",
        "1_24_the_summoning",
        "1_25_braska_s_daughter",
        "1_26_good_night_oneshot",
        "2_01_yuna_s_theme",
        "2_02_sprouting",
        "2_04_silence_before_the_storm",
        "2_05_song_of_prayer_ifrit",
        "2_06_luca",
        "2_08_unwavering_decision",
        "2_09_the_splendid_performance",
        "2_10_confrontation",
        "2_11_blitz_off",
        "2_12_auron_s_theme",
        "2_13_mi_ihen_road",
        "2_14_brass_de_chocobo",
        "2_15_travel_company",
        "2_16_permitted_passage_oneshot",
        "2_17_seymour_s_theme",
        "2_18_twilight",
        "2_19_djose_temple",
        "2_20_song_of_prayer_ixion",
        "2_21_wanna_ride_the_ciparph",
        "2_22_rikku_s_theme",
        "2_23_guadosalam",
        "3_01_thunder_plain",
        "3_02_ject_s_theme",
        "3_03_macalania_forest",
        "3_04_sea_of_mists",
        "3_06_seymour_s_ambition",
        "3_07_song_of_prayer_shiva",
        "3_09_blazing_desert",
        "3_10_crisis",
        "3_11_the_truth_revealed",
        "3_12_start",
        "3_13_marriage_ceremony_oneshot",
        "3_14_raid",
        "3_15_tragedy_oneshot",
        "3_16_i_can_fly_oneshot",
        "3_17_path_of_repentance",
        "3_18_song_of_prayer_bahamut",
        "3_19_time_of_judgment",
        "3_20_my_father_s_murderer",
        "4_01_yuna_s_decision",
        "4_02_lulu_s_theme",
        "4_03_brave_advancement",
        "4_04_song_of_prayer_bodyguard",
        "4_05_people_of_the_north_pole",
        "4_06_song_of_prayer_the_lonzo",
        "4_07_wandering_flame",
        "4_08_someday_the_dream_will_end",
        "4_09_song_of_prayer_yunalesca",
        "4_10_challenge",
        "4_11_at_the_end_of_the_abyss",
        "4_12_darkness",
        "4_13_song_of_prayer_spira",
        "4_14_the_deceased_laugh",
        "4_15_seymour_battle",
        "4_16_song_of_prayer_anima",
        "4_17_summoned_beasts_battle",
        "4_18_decisive_battle",
        "m_01_inori_effect",
        "m_05_the_temple_band",
        "m_07_reception_for_great_sage_micah",
        "m_08_the_advancers",
        "m_56_illusion",
        "m_58_nostalgia",
        "m_69_hum_of_the_fayth_oneshot",
        "m_71_wakka_s_theme",
        ];
}
