using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using EduSim.Analyse.BusinessLayer;
using System.Collections;
using EduSim.CoreFramework.DTO;
using EduSim.CoreFramework.Common;
using org.drools.dotnet.compiler;
using org.drools.dotnet.rule;

namespace EduSim.Analyse
{
    /**
     * Create the User
     * Create the Team
     * Associate the Users to the Team
     * Create a Game
     * Associate the team to the Game
     * */
    class Program
    {
        /****
         * GetCurrentRoundIdentifier
         * Calculate the Optimal Market Demand for this round (GetMarketDemand)
         * Calculate the supply, if supply is less then demand, purchase everything (GetSupply)
         * If supply is more then demand, choose the right product(s) as criteria below
         * 
         * Get the product with maximum customer awareness (GetCustomerAwareness)
         * Get Product information for each participante using ProductDataView, this contains, 
         *      a. ProductId
         *      b. Performance
         *      c. Size
         *      d. Reliability
         *      e. Cost
         *      f. Marketing Spend
         *      g. Sales Spend
         *      h. Customer satisfaction Index from past data
         * Get the R&D data and compare against the RoundCritera for Performance and Size
         * Get the max Reliability as per the GameCriteria
         * Get the minimum price as per the GameCriteria
         * Get the best product
         * */
        static void Main(string[] args)
        {
            Edusim db = new Edusim(Constants.ConnectionString);
            Round round = (from r in db.Round
                          where r.Id == 37
                          select r).ToList().FirstOrDefault();

            ResultsManager.Run(round);
        }
    }
}
