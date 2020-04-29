using ElRaccoone.Tweens.Core;
using UnityEngine;

namespace ElRaccoone.Tweens {
  public static class LocalEulerAnglesZTween {
    public static Tween<float> TweenLocalEulerAnglesZ (this Component self, float to, float duration) =>
      self.gameObject.TweenLocalEulerAnglesZ (to, duration);

    public static Tween<float> TweenLocalEulerAnglesZ (this GameObject self, float to, float duration) =>
      self.AddComponent<Tween> ().Finalize (duration, to);

    private class Tween : Tween<float> {
      private Quaternion quaternionValueFrom;
      private Quaternion quaternionValueTo;

      public override bool OnInitialize () {
        return true;
      }

      public override float OnGetFrom () {
        return this.transform.localEulerAngles.z;
      }

      public override void OnUpdate (float easedTime) {
        this.quaternionValueFrom = Quaternion.Euler (this.transform.localEulerAngles.x, this.transform.localEulerAngles.y, this.valueFrom);
        this.quaternionValueTo = Quaternion.Euler (this.transform.localEulerAngles.x, this.transform.localEulerAngles.y, this.valueTo);
        this.transform.localRotation = Quaternion.Lerp (this.quaternionValueFrom, this.quaternionValueTo, easedTime);
      }
    }
  }
}