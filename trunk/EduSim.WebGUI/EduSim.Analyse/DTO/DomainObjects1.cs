using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EduSim.Analyse.DTO
{
    class CurrentRoundForecast
    {
        public int SegmentTypeId
        {
            get;
            set;
        }

        public double Quantity
        {
            get;
            set;
        }
    }

    class CurrentRoundDemand
    {
        public int SegmentTypeId
        {
            get;
            set;
        }

        public double Quantity
        {
            get;
            set;
        }

        public double Performance 
        {
            get;
            set;
        }

        public double Size
        {
            get;
            set;
        }
    }

    public class CurrentRoundProductWiseInformation
    {
        public CurrentRoundProductWiseInformation(int roundProductId, int segmentTypeId, double ranking)
        {
            RoundProductId = roundProductId;
            SegmentTypeId = segmentTypeId;
            Ranking = ranking;
        }

        public int RoundProductId
        {
            get;
            set;
        }

        public int SegmentTypeId
        {
            get;
            set;
        }

        public double PurchasedQuantity
        {
            get;
            set;
        }

        public double Ranking
        {
            get;
            set;
        }
    }
}
