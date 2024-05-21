namespace Siren.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public static class sequenceConfig
{
    public static ConfigVariable custom(string key, string value)
         => Siren.sequenceConfig.custom(key, value);
    public static ConfigVariable arrowMarkerAbsolute(bool b)
         => Siren.sequenceConfig.arrowMarkerAbsolute(b);
    public static ConfigVariable hideUnusedParticipants(bool b)
         => Siren.sequenceConfig.hideUnusedParticipants(b);
    public static ConfigVariable activationWidth(int px)
         => Siren.sequenceConfig.activationWidth(px);   
    public static ConfigVariable diagramMarginX(int px)
         => Siren.sequenceConfig.diagramMarginX(px);
    public static ConfigVariable diagramMarginY(int px)
         => Siren.sequenceConfig.diagramMarginY(px)  ;
    public static ConfigVariable actorMargin(int px)
         => Siren.sequenceConfig.actorMargin(px);
    public static ConfigVariable width(int px)
         => Siren.sequenceConfig.width(px);
    public static ConfigVariable height(int px)
         => Siren.sequenceConfig.height(px);
    public static ConfigVariable boxMargin(int px)
         => Siren.sequenceConfig.boxMargin(px);
    public static ConfigVariable boxTextMargin(int px)
         => Siren.sequenceConfig.boxTextMargin(px);
    public static ConfigVariable noteMargin(int px)
         => Siren.sequenceConfig.noteMargin(px);
    public static ConfigVariable messageAlign(string name)
         => Siren.sequenceConfig.messageAlign(name);
    public static ConfigVariable messageAlignLeft
         => Siren.sequenceConfig.messageAlignLeft;
    public static ConfigVariable messageAligncCenter
         => Siren.sequenceConfig.messageAligncCenter;
    public static ConfigVariable messageAlignRight
         => Siren.sequenceConfig.messageAlignRight;
    public static ConfigVariable mirrorActors(bool b)
         => Siren.sequenceConfig.mirrorActors(b);
    public static ConfigVariable bottomMarginAdj(int px)
         => Siren.sequenceConfig.bottomMarginAdj(px);
    public static ConfigVariable showSequenceNumbers(bool b)
         => Siren.sequenceConfig.showSequenceNumbers(b);
    public static ConfigVariable actorFontSize(string s)
         => Siren.sequenceConfig.actorFontSize(s);
    public static ConfigVariable actorFontWeight(string s)
         => Siren.sequenceConfig.actorFontWeight(s);
    public static ConfigVariable noteFontSize(string s)
         => Siren.sequenceConfig.noteFontSize(s);
    public static ConfigVariable noteFontWeight(string s)
         => Siren.sequenceConfig.noteFontWeight(s);
    public static ConfigVariable noteAlign(string s)
         => Siren.sequenceConfig.noteAlign(s);
    public static ConfigVariable noteAlignLeft
         => Siren.sequenceConfig.noteAlignLeft;
    public static ConfigVariable noteAlignCenter
         => Siren.sequenceConfig.noteAlignCenter;
    public static ConfigVariable noteAlignRight
         => Siren.sequenceConfig.noteAlignRight;
    public static ConfigVariable messageFontSize(string s)
         => Siren.sequenceConfig.messageFontSize(s);
    public static ConfigVariable messageFontWeight(string s)
         => Siren.sequenceConfig.messageFontWeight(s);
    public static ConfigVariable wrap(bool b)
         => Siren.sequenceConfig.wrap(b);
    public static ConfigVariable wrapPadding(int px)
         => Siren.sequenceConfig.wrapPadding(px);
}