using System;
using System.Collections.Generic;
using System.Text;

namespace second_lab_oop
{
    class Context
    {
        private IStrategy strategy;
        public Context()
        { }
        public Context(IStrategy strategy_)
        {
            this.strategy = strategy_;
        }
        public void SetStrategy(IStrategy strategy_)
        {
            this.strategy = strategy_;
        }
        public List<Beer> Analyze_XML() 
        {
            return this.strategy.Commit();
        }
    }
}
