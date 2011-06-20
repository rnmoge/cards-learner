using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Media
{
    public class Player
    {
        private String Pcommand;
        private bool isOpen;
        private static Player player;
        private int baseVolumn;
        private int trebleVolumn;
        private int leftVolumn;
        private int rightVolumn;
        private int masterVolumn;
        //--------------------------------------------------------------------------
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);
        //--------------------------------------------------------------------------
        public Player()
        {
            this.Bass = 10 * 100;
            this.LeftVolume = 10 * 100;
            this.MasterVolume = 10 * 100;
            this.RightVolume = 10 * 100;
            this.Treble = 10 * 100;
        }
        //--------------------------------------------------------------------------
        public static Player GetPlayer()
        {
            if (player == null)
                player = new Player();
            return player;
        }
        //--------------------------------------------------------------------------
        public void Close()
        {
            Pcommand = "close MediaFile";
            mciSendString(Pcommand, null, 0, IntPtr.Zero);
            isOpen = false;
        }
        //--------------------------------------------------------------------------
        public void Open(string sFileName)
        {
            Pcommand = "open \"" + sFileName + "\" type mpegvideo alias MediaFile";
            mciSendString(Pcommand, null, 0, IntPtr.Zero);
            isOpen = true;
        }
        //--------------------------------------------------------------------------
        public void Play(bool loop)
        {
            if (isOpen)
            {
                Pcommand = "play MediaFile";
                if (loop)
                    Pcommand += " REPEAT";
                mciSendString(Pcommand, null, 0, IntPtr.Zero);
                this.Bass = this.Bass;
                this.LeftVolume = this.LeftVolume;
                this.MasterVolume = this.MasterVolume;
                this.RightVolume = this.RightVolume;
                this.Treble = this.Treble;
            }
        }
        //--------------------------------------------------------------------------
        public void Play(string FileName)
        {
            if (isOpen == true)
            {
                Close();
            }
            Open(FileName);
            Play(false);
        }
        //--------------------------------------------------------------------------
        public void Pause()
        {
            Pcommand = "pause MediaFile";
            mciSendString(Pcommand, null, 0, IntPtr.Zero);
        }
        //--------------------------------------------------------------------------
        public String Status()
        {
            int i = 128;
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder(i);
            mciSendString("status MediaFile mode", stringBuilder, i, IntPtr.Zero);
            return stringBuilder.ToString();
        }
        //--------------------------------------------------------------------------
        public int LeftVolume
        {
            get
            {
                return leftVolumn;
            }
            set
            {
                mciSendString(string.Concat("setaudio MediaFile left volume to ", value), null, 0, IntPtr.Zero);
                leftVolumn = value;
            }
        }
        //--------------------------------------------------------------------------
        public int RightVolume
        {
            get
            {
                return rightVolumn;
            }
            set
            {
                mciSendString(string.Concat("setaudio MediaFile right volume to ", value), null, 0, IntPtr.Zero);
                rightVolumn = value;
            }
        }
        //--------------------------------------------------------------------------
        public int MasterVolume
        {
            get
            {
                return masterVolumn;
            }
            set
            {
                mciSendString(string.Concat("setaudio MediaFile volume to ", value), null, 0, IntPtr.Zero);
                masterVolumn = value;
            }
        }
        //--------------------------------------------------------------------------
        public int Bass
        {
            get
            {
                return baseVolumn;
            }
            set
            {
                mciSendString(string.Concat("setaudio MediaFile bass to ", value), null, 0, IntPtr.Zero);
                baseVolumn = value;
            }
        }
        //--------------------------------------------------------------------------
        public int Treble
        {
            get
            {
                return trebleVolumn;
            }
            set
            {
                mciSendString(string.Concat("setaudio MediaFile treble to ", value), null, 0, IntPtr.Zero);
                trebleVolumn = value;
            }
        }
        //--------------------------------------------------------------------------
        public bool IsPaused()
        {
            return Pcommand == "pause MediaFile";
        }
        //--------------------------------------------------------------------------
        public bool IsPlaying()
        {
            return Status() == "playing";
        }
        //--------------------------------------------------------------------------
        public bool IsOpen()
        {
            return isOpen;
        }
        //--------------------------------------------------------------------------
    }

}
