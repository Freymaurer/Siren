namespace Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public static class sequenceConfig
{
    public static (string, string) custom(string key, string value)
         => Siren.sequenceConfig.custom(key, value).ToValueTuple();
    public static (string, string) arrowMarkerAbsolute(bool b)
         => Siren.sequenceConfig.arrowMarkerAbsolute(b).ToValueTuple();
    public static (string, string) hideUnusedParticipants(bool b)
         => Siren.sequenceConfig.hideUnusedParticipants(b).ToValueTuple();
    public static (string, string) activationWidth(int px)
         => Siren.sequenceConfig.activationWidth(px).ToValueTuple();   
    public static (string, string) diagramMarginX(int px)
         => Siren.sequenceConfig.diagramMarginX(px).ToValueTuple();
    public static (string, string) diagramMarginY(int px)
         => Siren.sequenceConfig.diagramMarginY(px).ToValueTuple()  ;
    public static (string, string) actorMargin(int px)
         => Siren.sequenceConfig.actorMargin(px).ToValueTuple();
    public static (string, string) width(int px)
         => Siren.sequenceConfig.width(px).ToValueTuple();
    public static (string, string) height(int px)
         => Siren.sequenceConfig.height(px).ToValueTuple();
    public static (string, string) boxMargin(int px)
         => Siren.sequenceConfig.boxMargin(px).ToValueTuple();
    public static (string, string) boxTextMargin(int px)
         => Siren.sequenceConfig.boxTextMargin(px).ToValueTuple();
    public static (string, string) noteMargin(int px)
         => Siren.sequenceConfig.noteMargin(px).ToValueTuple();
    public static (string, string) messageAlign(string name)
         => Siren.sequenceConfig.messageAlign(name).ToValueTuple();
    public static (string, string) messageAlignLeft
         => Siren.sequenceConfig.messageAlignLeft.ToValueTuple();
    public static (string, string) messageAligncCenter
         => Siren.sequenceConfig.messageAligncCenter.ToValueTuple();
    public static (string, string) messageAlignRight
         => Siren.sequenceConfig.messageAlignRight.ToValueTuple();
    public static (string, string) mirrorActors(bool b)
         => Siren.sequenceConfig.mirrorActors(b).ToValueTuple();
    public static (string, string) bottomMarginAdj(int px)
         => Siren.sequenceConfig.bottomMarginAdj(px).ToValueTuple();
    public static (string, string) showSequenceNumbers(bool b)
         => Siren.sequenceConfig.showSequenceNumbers(b).ToValueTuple();
    public static (string, string) actorFontSize(string s)
         => Siren.sequenceConfig.actorFontSize(s).ToValueTuple();
    public static (string, string) actorFontWeight(string s)
         => Siren.sequenceConfig.actorFontWeight(s).ToValueTuple();
    public static (string, string) noteFontSize(string s)
         => Siren.sequenceConfig.noteFontSize(s).ToValueTuple();
    public static (string, string) noteFontWeight(string s)
         => Siren.sequenceConfig.noteFontWeight(s).ToValueTuple();
    public static (string, string) noteAlign(string s)
         => Siren.sequenceConfig.noteAlign(s).ToValueTuple();
    public static (string, string) noteAlignLeft
         => Siren.sequenceConfig.noteAlignLeft.ToValueTuple();
    public static (string, string) noteAlignCenter
         => Siren.sequenceConfig.noteAlignCenter.ToValueTuple();
    public static (string, string) noteAlignRight
         => Siren.sequenceConfig.noteAlignRight.ToValueTuple();
    public static (string, string) messageFontSize(string s)
         => Siren.sequenceConfig.messageFontSize(s).ToValueTuple();
    public static (string, string) messageFontWeight(string s)
         => Siren.sequenceConfig.messageFontWeight(s).ToValueTuple();
    public static (string, string) wrap(bool b)
         => Siren.sequenceConfig.wrap(b).ToValueTuple();
    public static (string, string) wrapPadding(int px)
         => Siren.sequenceConfig.wrapPadding(px).ToValueTuple();
}