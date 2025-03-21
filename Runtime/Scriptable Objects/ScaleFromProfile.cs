using DG.Tweening;
using UnityEngine;

namespace Tweening
{
    [CreateAssetMenu(fileName = "Scale From Tween", menuName = "Tweening/Scale From")]
    public class ScaleFromProfile : TweenProfile
    {
        [Header("Scale Config")]
        [SerializeField]
        [Range(0, 1f)]
        private float scaleFrom = 0.5f;
        private Vector3 originalScale;

        public override void InitializeProfile(RectTransform rect)
        {
            base.InitializeProfile(rect);
            originalScale = rect.localScale;
        }

        public override Sequence JoinAnimateInSequence(Sequence seq) =>
            seq.Join(Target.DOScale(originalScale, TimeIn).SetEase(EaseIn).SetUpdate(UseUnscaledTime));

        public override Sequence JoinAnimateOutSequence(Sequence seq) =>
            seq.Join(Target.DOScale(originalScale * scaleFrom, TimeOut).SetEase(EaseOut).SetUpdate(UseUnscaledTime));

        public override void ResetTween() => Target.localScale = originalScale * scaleFrom;
    }
}
