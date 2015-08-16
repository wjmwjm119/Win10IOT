// Copyright (c) Microsoft. All rights reserved.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DisplayFont
{
    /* FontCharacterDescripter contains font information for a  single character */
    public class FontCharacterDescriptor
    {
        public  char character;
        public  Int32 characterWidthPx;
        public  byte[] characterDataUp;
        public  byte[] characterDataDown;


        public FontCharacterDescriptor(Char Chr, byte[] CharData)
        {
            character = Chr;
            characterWidthPx = (CharData.Length / 2)+1;

            characterDataUp = new byte[characterWidthPx];
            characterDataDown =new byte[characterWidthPx];

            Array.Copy(CharData, 0, characterDataUp, 0, characterWidthPx-1);
            Array.Copy(CharData, characterWidthPx-1, characterDataDown, 0, characterWidthPx-1);

   //      Debug.WriteLine(characterDataUp[0].ToString());
   //      Debug.WriteLine(characterDataDown[0].ToString());

   //      CharacterData = CharData;


        }
    }

    /* This class contains the character data needed to output render text on the display */
    public static class DisplayFontTable
    {
        /* Takes and returns the character descriptor for the corresponding Char if it exists */
        public static  FontCharacterDescriptor GetCharacterDescriptor(Char Chr)
        {
            foreach (FontCharacterDescriptor CharDescriptor in FontTable)
            {
                if (CharDescriptor.character == Chr)
                {
                    return CharDescriptor;
                }
            }
            return null;
        }

        /* Table with all the character data */
        private static readonly FontCharacterDescriptor[] FontTable =
        {
            new FontCharacterDescriptor(' ' ,new byte[]{0x00,0x00,0x00,0x00,0x00,0x00}),
            new FontCharacterDescriptor('!' ,new byte[]{0xFE,0x05}),
            new FontCharacterDescriptor('"' ,new byte[]{0x1E,0x00,0x1E,0x00,0x00,0x00}),
            new FontCharacterDescriptor('#' ,new byte[]{0x80,0x90,0xF0,0x9E,0xF0,0x9E,0x10,0x00,0x07,0x00,0x07,0x00,0x00,0x00}),
            new FontCharacterDescriptor('$' ,new byte[]{0x38,0x44,0xFE,0x44,0x98,0x02,0x04,0x0F,0x04,0x03}),
            new FontCharacterDescriptor('%' ,new byte[]{0x0C,0x12,0x12,0x8C,0x40,0x20,0x10,0x88,0x84,0x00,0x00,0x02,0x01,0x00,0x00,0x00,0x03,0x04,0x04,0x03}),
            new FontCharacterDescriptor('&' ,new byte[]{0x80,0x5C,0x22,0x62,0x9C,0x00,0x00,0x03,0x04,0x04,0x04,0x05,0x02,0x05}),
            new FontCharacterDescriptor('\'',new byte[]{0x1E,0x00}),
            new FontCharacterDescriptor('(' ,new byte[]{0xF0,0x0C,0x02,0x07,0x18,0x20}),
            new FontCharacterDescriptor(')' ,new byte[]{0x02,0x0C,0xF0,0x20,0x18,0x07}),
            new FontCharacterDescriptor('*' ,new byte[]{0x14,0x18,0x0E,0x18,0x14,0x00,0x00,0x00,0x00,0x00}),
            new FontCharacterDescriptor('+' ,new byte[]{0x40,0x40,0xF0,0x40,0x40,0x00,0x00,0x01,0x00,0x00}),
            new FontCharacterDescriptor(',' ,new byte[]{0x00,0x00,0x08,0x04}),
            new FontCharacterDescriptor('-' ,new byte[]{0x40,0x40,0x40,0x40,0x00,0x00,0x00,0x00}),
            new FontCharacterDescriptor('.' ,new byte[]{0x00,0x04}),
            new FontCharacterDescriptor('/' ,new byte[]{0x00,0x80,0x70,0x0E,0x1C,0x03,0x00,0x00}),
            new FontCharacterDescriptor('0' ,new byte[]{0xFC,0x02,0x02,0x02,0xFC,0x03,0x04,0x04,0x04,0x03}),
            new FontCharacterDescriptor('1' ,new byte[]{0x04,0x04,0xFE,0x00,0x00,0x07}),
            new FontCharacterDescriptor('2' ,new byte[]{0x0C,0x82,0x42,0x22,0x1C,0x07,0x04,0x04,0x04,0x04}),
            new FontCharacterDescriptor('3' ,new byte[]{0x04,0x02,0x22,0x22,0xDC,0x02,0x04,0x04,0x04,0x03}),
            new FontCharacterDescriptor('4' ,new byte[]{0xC0,0xA0,0x98,0x84,0xFE,0x00,0x00,0x00,0x00,0x07}),
            new FontCharacterDescriptor('5' ,new byte[]{0x7E,0x22,0x22,0x22,0xC2,0x02,0x04,0x04,0x04,0x03}),
            new FontCharacterDescriptor('6' ,new byte[]{0xFC,0x42,0x22,0x22,0xC4,0x03,0x04,0x04,0x04,0x03}),
            new FontCharacterDescriptor('7' ,new byte[]{0x02,0x02,0xC2,0x32,0x0E,0x00,0x07,0x00,0x00,0x00}),
            new FontCharacterDescriptor('8' ,new byte[]{0xDC,0x22,0x22,0x22,0xDC,0x03,0x04,0x04,0x04,0x03}),
            new FontCharacterDescriptor('9' ,new byte[]{0x3C,0x42,0x42,0x22,0xFC,0x02,0x04,0x04,0x04,0x03}),
            new FontCharacterDescriptor(':' ,new byte[]{0x10,0x04}),
            new FontCharacterDescriptor(';' ,new byte[]{0x00,0x10,0x08,0x04}),
            new FontCharacterDescriptor('<' ,new byte[]{0x40,0xE0,0xB0,0x18,0x08,0x00,0x00,0x01,0x03,0x02}),
            new FontCharacterDescriptor('=' ,new byte[]{0xA0,0xA0,0xA0,0xA0,0xA0,0x00,0x00,0x00,0x00,0x00}),
            new FontCharacterDescriptor('>' ,new byte[]{0x08,0x18,0xB0,0xE0,0x40,0x02,0x03,0x01,0x00,0x00}),
            new FontCharacterDescriptor('?' ,new byte[]{0x0C,0x02,0xC2,0x22,0x1C,0x00,0x00,0x05,0x00,0x00}),
            new FontCharacterDescriptor('@' ,new byte[]{0xF0,0x0C,0x02,0x02,0xE1,0x11,0x11,0x91,0x72,0x02,0x0C,0xF0,0x00,0x03,0x04,0x04,0x08,0x09,0x09,0x08,0x09,0x05,0x05,0x00}),
            new FontCharacterDescriptor('A' ,new byte[]{0x00,0x80,0xE0,0x98,0x86,0x98,0xE0,0x80,0x00,0x06,0x01,0x00,0x00,0x00,0x00,0x00,0x01,0x06}),
            new FontCharacterDescriptor('B' ,new byte[]{0xFE,0x22,0x22,0x22,0x22,0x22,0xDC,0x07,0x04,0x04,0x04,0x04,0x04,0x03}),
            new FontCharacterDescriptor('C' ,new byte[]{0xF8,0x04,0x02,0x02,0x02,0x02,0x04,0x08,0x01,0x02,0x04,0x04,0x04,0x04,0x02,0x01}),
            new FontCharacterDescriptor('D' ,new byte[]{0xFE,0x02,0x02,0x02,0x02,0x02,0x04,0xF8,0x07,0x04,0x04,0x04,0x04,0x04,0x02,0x01}),
            new FontCharacterDescriptor('E' ,new byte[]{0xFE,0x22,0x22,0x22,0x22,0x22,0x02,0x07,0x04,0x04,0x04,0x04,0x04,0x04}),
            new FontCharacterDescriptor('F' ,new byte[]{0xFE,0x22,0x22,0x22,0x22,0x22,0x02,0x07,0x00,0x00,0x00,0x00,0x00,0x00}),
            new FontCharacterDescriptor('G' ,new byte[]{0xF8,0x04,0x02,0x02,0x02,0x42,0x44,0xC8,0x01,0x02,0x04,0x04,0x04,0x04,0x02,0x07}),
            new FontCharacterDescriptor('H' ,new byte[]{0xFE,0x20,0x20,0x20,0x20,0x20,0x20,0xFE,0x07,0x00,0x00,0x00,0x00,0x00,0x00,0x07}),
            new FontCharacterDescriptor('I' ,new byte[]{0xFE,0x07}),
            new FontCharacterDescriptor('J' ,new byte[]{0x00,0x00,0x00,0x00,0xFE,0x03,0x04,0x04,0x04,0x03}),
            new FontCharacterDescriptor('K' ,new byte[]{0xFE,0x20,0x50,0x88,0x04,0x02,0x00,0x07,0x00,0x00,0x00,0x01,0x02,0x04}),
            new FontCharacterDescriptor('L' ,new byte[]{0xFE,0x00,0x00,0x00,0x00,0x00,0x07,0x04,0x04,0x04,0x04,0x04}),
            new FontCharacterDescriptor('M' ,new byte[]{0xFE,0x18,0x60,0x80,0x00,0x80,0x60,0x18,0xFE,0x07,0x00,0x00,0x01,0x06,0x01,0x00,0x00,0x07}),
            new FontCharacterDescriptor('N' ,new byte[]{0xFE,0x04,0x18,0x20,0x40,0x80,0x00,0xFE,0x07,0x00,0x00,0x00,0x00,0x01,0x02,0x07}),
            new FontCharacterDescriptor('O' ,new byte[]{0xF8,0x04,0x02,0x02,0x02,0x02,0x04,0xF8,0x01,0x02,0x04,0x04,0x04,0x04,0x02,0x01}),
            new FontCharacterDescriptor('P' ,new byte[]{0xFE,0x42,0x42,0x42,0x42,0x42,0x24,0x18,0x07,0x00,0x00,0x00,0x00,0x00,0x00,0x00}),
            new FontCharacterDescriptor('Q' ,new byte[]{0xF8,0x04,0x02,0x02,0x02,0x02,0x04,0xF8,0x01,0x02,0x04,0x04,0x04,0x05,0x02,0x05}),
            new FontCharacterDescriptor('R' ,new byte[]{0xFE,0x42,0x42,0x42,0x42,0x42,0x64,0x98,0x00,0x07,0x00,0x00,0x00,0x00,0x00,0x00,0x03,0x04}),
            new FontCharacterDescriptor('S' ,new byte[]{0x1C,0x22,0x22,0x22,0x42,0x42,0x8C,0x03,0x04,0x04,0x04,0x04,0x04,0x03}),
            new FontCharacterDescriptor('T' ,new byte[]{0x02,0x02,0x02,0x02,0xFE,0x02,0x02,0x02,0x02,0x00,0x00,0x00,0x00,0x07,0x00,0x00,0x00,0x00}),
            new FontCharacterDescriptor('U' ,new byte[]{0xFE,0x00,0x00,0x00,0x00,0x00,0x00,0xFE,0x01,0x02,0x04,0x04,0x04,0x04,0x02,0x01}),
            new FontCharacterDescriptor('V' ,new byte[]{0x06,0x18,0x60,0x80,0x00,0x80,0x60,0x18,0x06,0x00,0x00,0x00,0x01,0x06,0x01,0x00,0x00,0x00}),
            new FontCharacterDescriptor('W' ,new byte[]{0x0E,0x30,0xC0,0x00,0xC0,0x30,0x0E,0x30,0xC0,0x00,0xC0,0x30,0x0E,0x00,0x00,0x01,0x06,0x01,0x00,0x00,0x00,0x01,0x06,0x01,0x00,0x00}),
            new FontCharacterDescriptor('X' ,new byte[]{0x06,0x08,0x90,0x60,0x60,0x90,0x08,0x06,0x06,0x01,0x00,0x00,0x00,0x00,0x01,0x06}),
            new FontCharacterDescriptor('Y' ,new byte[]{0x06,0x08,0x10,0x20,0xC0,0x20,0x10,0x08,0x06,0x00,0x00,0x00,0x00,0x07,0x00,0x00,0x00,0x00}),
            new FontCharacterDescriptor('Z' ,new byte[]{0x02,0x82,0x42,0x22,0x1A,0x06,0x06,0x05,0x04,0x04,0x04,0x04}),
            new FontCharacterDescriptor('[' ,new byte[]{0xFE,0x02,0x02,0x3F,0x20,0x20}),
            new FontCharacterDescriptor('\\',new byte[]{0x0E,0x70,0x80,0x00,0x00,0x00,0x03,0x1C}),
            new FontCharacterDescriptor('^' ,new byte[]{0x02,0x02,0xFE,0x20,0x20,0x3F}),
            new FontCharacterDescriptor('_' ,new byte[]{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x10,0x10,0x10,0x10,0x10,0x10,0x10}),
            new FontCharacterDescriptor('`' ,new byte[]{0x02,0x04,0x00,0x00}),
            new FontCharacterDescriptor('a' ,new byte[]{0xA0,0x50,0x50,0x50,0x50,0xE0,0x00,0x03,0x04,0x04,0x04,0x04,0x03,0x04}),
            new FontCharacterDescriptor('b' ,new byte[]{0xFE,0x20,0x10,0x10,0x10,0xE0,0x07,0x02,0x04,0x04,0x04,0x03}),
            new FontCharacterDescriptor('c' ,new byte[]{0xE0,0x10,0x10,0x10,0x10,0x20,0x03,0x04,0x04,0x04,0x04,0x02}),
            new FontCharacterDescriptor('d' ,new byte[]{0xE0,0x10,0x10,0x10,0x20,0xFE,0x03,0x04,0x04,0x04,0x02,0x07}),
            new FontCharacterDescriptor('e' ,new byte[]{0xE0,0x90,0x90,0x90,0x90,0xE0,0x03,0x04,0x04,0x04,0x04,0x02}),
            new FontCharacterDescriptor('f' ,new byte[]{0x10,0xFC,0x12,0x00,0x07,0x00}),
            new FontCharacterDescriptor('g' ,new byte[]{0xE0,0x10,0x10,0x10,0x20,0xF0,0x03,0x24,0x24,0x24,0x22,0x1F}),
            new FontCharacterDescriptor('h' ,new byte[]{0xFE,0x20,0x10,0x10,0xE0,0x07,0x00,0x00,0x00,0x07}),
            new FontCharacterDescriptor('i' ,new byte[]{0xF2,0x07}),
            new FontCharacterDescriptor('j' ,new byte[]{0x00,0xF2,0x20,0x1F}),
            new FontCharacterDescriptor('k' ,new byte[]{0xFE,0x80,0xC0,0x20,0x10,0x00,0x07,0x00,0x00,0x01,0x02,0x04}),
            new FontCharacterDescriptor('l' ,new byte[]{0xFE,0x07}),
            new FontCharacterDescriptor('m' ,new byte[]{0xF0,0x20,0x10,0x10,0xE0,0x20,0x10,0x10,0xE0,0x07,0x00,0x00,0x00,0x07,0x00,0x00,0x00,0x07}),
            new FontCharacterDescriptor('n' ,new byte[]{0xF0,0x20,0x10,0x10,0xE0,0x07,0x00,0x00,0x00,0x07}),
            new FontCharacterDescriptor('o' ,new byte[]{0xE0,0x10,0x10,0x10,0x10,0xE0,0x03,0x04,0x04,0x04,0x04,0x03}),
            new FontCharacterDescriptor('p' ,new byte[]{0xF0,0x20,0x10,0x10,0x10,0xE0,0x3F,0x02,0x04,0x04,0x04,0x03}),
            new FontCharacterDescriptor('q' ,new byte[]{0xE0,0x10,0x10,0x10,0x20,0xF0,0x03,0x04,0x04,0x04,0x02,0x3F}),
            new FontCharacterDescriptor('r' ,new byte[]{0xF0,0x20,0x10,0x07,0x00,0x00}),
            new FontCharacterDescriptor('s' ,new byte[]{0x60,0x90,0x90,0x90,0x20,0x02,0x04,0x04,0x04,0x03}),
            new FontCharacterDescriptor('t' ,new byte[]{0x10,0xFC,0x10,0x00,0x03,0x04}),
            new FontCharacterDescriptor('u' ,new byte[]{0xF0,0x00,0x00,0x00,0xF0,0x03,0x04,0x04,0x02,0x07}),
            new FontCharacterDescriptor('v' ,new byte[]{0x30,0xC0,0x00,0x00,0x00,0xC0,0x30,0x00,0x00,0x03,0x04,0x03,0x00,0x00}),
            new FontCharacterDescriptor('w' ,new byte[]{0x30,0xC0,0x00,0xC0,0x30,0xC0,0x00,0xC0,0x30,0x00,0x01,0x06,0x01,0x00,0x01,0x06,0x01,0x00}),
            new FontCharacterDescriptor('x' ,new byte[]{0x10,0x20,0xC0,0xC0,0x20,0x10,0x04,0x02,0x01,0x01,0x02,0x04}),
            new FontCharacterDescriptor('y' ,new byte[]{0x30,0xC0,0x00,0x00,0x00,0xC0,0x30,0x20,0x20,0x13,0x0C,0x03,0x00,0x00}),
            new FontCharacterDescriptor('z' ,new byte[]{0x10,0x90,0x50,0x30,0x06,0x05,0x04,0x04}),
            new FontCharacterDescriptor('{' ,new byte[]{0x80,0x80,0x7C,0x02,0x02,0x00,0x00,0x1F,0x20,0x20}),
            new FontCharacterDescriptor('|' ,new byte[]{0xFE,0x3F}),
            new FontCharacterDescriptor('}' ,new byte[]{0x02,0x02,0x7C,0x80,0x80,0x20,0x20,0x1F,0x00,0x00}),
            new FontCharacterDescriptor('~' ,new byte[]{0x0C,0x02,0x02,0x04,0x08,0x08,0x06,0x00,0x00,0x00,0x00,0x00,0x00,0x00}),
        };
    }
}