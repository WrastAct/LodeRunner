using System;
using System.Collections.Generic;
using System.Text;

namespace LodeRunner.Logic
{
    class FieldPair
    {
        private int currentGold;
        private int maxGold;
        private int currentField;
        private GameField[] fields;

        public int CField
        {
            get => currentField;
            set => currentField = value % 2;
        }

        public GameField[] Fields
        {
            get => fields;
        }

        public int CGold
        {
            get => currentGold;
            set => currentGold = value;
        }

        public int MGold
        {
            get => maxGold;
            set => maxGold = value;
        }


        public FieldPair(GameField field1, GameField field2)
        {
            fields = new GameField[] { field1, field2 };
            CField = 1;
            MGold = field1.TotalGold + field2.TotalGold;
            CGold = 0;
        }

        public GameField this[int i]
        {
            get
            {
                return fields[i % 2];
            }
            private set => fields[i % 2] = value;
        }

        public GameField NextField()
        {
            CField++;
            return this[CField];
        }

        public bool CheckGold()
        {
            return MGold == CGold;
        }
    }
}
