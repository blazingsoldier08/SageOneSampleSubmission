﻿using SageOneSample.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SageOneSample.Repository
{
    public interface ISudokuSolutionsRepository
    {
        string GetSolutionByPuzzle(string partialPuzzle);
        string GetSample();
        
    }
}
