using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StrategyGameHelper
{
    public enum Direction
    {
        North, South, East, West
    }
    public enum RuleType
    {
        None, Allowed, Disallowed
    }

    public class TileRule
    {
        public string Identifier { get; set; }
        public int Base { get; set; }
        public int Neighbor { get; set; }
        public Direction Direction { get; set; }
        public RuleType Type { get; set; }

        public TileRule()
        {

        }
        public TileRule(int b, int neighbor, Direction dir, string identifier, RuleType t)
        {
            Base = b;
            Neighbor = neighbor;
            Direction = dir;
            Identifier = identifier;
            Type = t;
        }

        public TileRule Flip()
        {
            return new TileRule(this.Neighbor, this.Base, ReverseDirection(Direction), this.Identifier, this.Type);
        }
        public override bool Equals(Object obj)
        {
            // If parameter is null return false:
            if ((object)obj == null) { return false; }

            var rule = obj as TileRule;

            // Return true if the fields match:
            var reversed = rule.Flip();
            return (Base == rule.Base && Neighbor == rule.Neighbor && Direction == rule.Direction) ||
                (Base == reversed.Base && Neighbor == reversed.Neighbor && Direction == reversed.Direction);
        }
        public override string ToString()
        {
            return Base + Direction.ToString() + Neighbor;
        }
        public static TileRule Parse(string rule)
        {
            /*try
            {
                var pattern = @"(^\d+)([A-z]+)(\d+$)";
                var matches = Regex.Matches(rule, pattern);
                Direction dir;
                if (!Enum.TryParse<Direction>(matches[0].Groups[2].Value, out dir))
                    throw new Exception("value1 is not valid member of enumeration MyEnum");
                return new TileRule(int.Parse(matches[0].Groups[1].Value), int.Parse(matches[0].Groups[3].Value), dir);
            }
            catch { return null; }*/
            return null;
        }
        public static Direction ReverseDirection(Direction dir)
        {
            switch (dir)
            {
                case Direction.North: return Direction.South;
                case Direction.South: return Direction.North;
                case Direction.East: return Direction.West;
                case Direction.West: return Direction.East;
                default: return dir;
            }
        }
    }
}
