using Plugin.MaterialDesignControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.CommunityToolkit.Effects;
using Xamarin.Forms;

namespace Patients.Helpers
{
    public class ShadowEffectBehaviour : Behavior<View>
    {
        private MaterialEntry entry;        

        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);

            entry = bindable as MaterialEntry;            

            entry.Focused += Entry_Focused;
            entry.Unfocused += Entry_Unfocused;
        }       

        protected override void OnDetachingFrom(BindableObject bindable)
        {
            base.OnDetachingFrom(bindable);

            entry = bindable as MaterialEntry;
                       
            entry.Focused -= Entry_Focused;
            entry.Unfocused -= Entry_Unfocused;
        }

        private void Entry_Focused(object sender, FocusEventArgs e)
        {
            ShadowEffect.SetColor(entry, Color.Gray);
            ShadowEffect.SetRadius(entry, 2);
            ShadowEffect.SetOpacity(entry, 1);            
        }        

        private void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            var effects = entry.Effects.Where(ef => ef.GetType() == typeof(ShadowEffect)).ToList();
            foreach (var effect in effects)
                entry.Effects.Remove(effect);
        }        
    }
}
