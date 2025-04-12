using Jypeli;

// TODO LISÄÄ LYÖNTIÄÄNI JA PALLOJEN TÖRMÄYS

/// <summary>
/// Luokka joka vastaa ääniefektien mäppäyksestä ja tarjoaa funktiot jolla ääniä voi toistaa.
/// </summary>
public class SFX
{
    readonly SoundEffect error = Game.LoadSoundEffect("false");
    readonly SoundEffect seina = Game.LoadSoundEffect("wall");
    readonly SoundEffect intro = Game.LoadSoundEffect("intro");
    readonly SoundEffect bgm = Game.LoadSoundEffect("bgm");
    readonly SoundEffect ball = Game.LoadSoundEffect("ball");
    readonly SoundEffect fail = Game.LoadSoundEffect("fail");
    readonly SoundEffect win = Game.LoadSoundEffect("win");
    readonly SoundEffect power = Game.LoadSoundEffect("power");
    readonly SoundEffect gameover = Game.LoadSoundEffect("gameover");
    readonly SoundEffect youwin = Game.LoadSoundEffect("youwin");

    private double VOLUMELEVEL = 1;

    /// <summary>
    /// Get/Set ääniefektien äänenvoimakkuuden.
    /// </summary>
    public double VolumeLevel
    {
        get { return VOLUMELEVEL; }
        set { VOLUMELEVEL = value; }
    }

    public void PlayWall()
    {
        seina.Play(VolumeLevel, 0, 0);
    }
    public void PlayError()
    {
        error.Play(VolumeLevel, 0, 0);
    }

    public void PlayMusic()
    {
        intro.Play(VolumeLevel / 2, 0, 0);
        Timer bgmTimer = new Timer
        {
            Interval = 139.70
        };
        bgmTimer.Timeout += delegate { bgm.Play(VolumeLevel / 2, 0, 0); };
        Timer.SingleShot(2.18, delegate { bgm.Play(VolumeLevel / 2, 0, 0); bgmTimer.Start(); });
    }

    public void PlayBall()
    {
        ball.Play(VolumeLevel, 0, 0);
    }

    public void PlayFail()
    {
        fail.Play(VolumeLevel, 0, 0);
    }

    public void PlayWin()
    {
        win.Play(VolumeLevel, 0, 0);
    }

    public void PlayPower()
    {
        power.Play(VolumeLevel, 0, 0);
    }

    public void StopPower()
    {
        power.Stop();
    }

    public void StopMusic()
    {
        intro.Stop();
        bgm.Stop();
    }

    public void PlayGameOver()
    {
        gameover.Play(VolumeLevel, 0, 0);
    }

    public void PlayYouWin()
    {
        youwin.Play(VolumeLevel, 0, 0);
    }

}