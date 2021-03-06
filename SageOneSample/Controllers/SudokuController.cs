﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SageOneSample.Models;
using SageOneSample.Business;

namespace SageOneSample.Controllers
{
    public class SudokuController : Controller
    {
        private IFindSolution _solutionFinder; 
        public SudokuController(IFindSolution solutionFinder)
        {
            _solutionFinder = solutionFinder;
        }

        // GET: Sudoku
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sudoku(string puzzleInputs)
        {
            //TODO: Implement real validation
            if (puzzleInputs.Length < 81)
            {
                var sudokuViewModel = BuildViewModel();
                return View(sudokuViewModel);
            }
            else
            {
                var sudokuViewModel = BuildViewModel(puzzleInputs);
                return View(sudokuViewModel);
            }
            
        }
        [HttpPost]
        public JsonResult SolvedSudokuJson(string puzzlePieces)
        {
            var svm = BuildViewModel(puzzlePieces);
            return Json(svm.PuzzlePieces, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SolvedPuzzle(string puzzleInputs)
        {
            
            return View(BuildViewModel(puzzleInputs));
        }


        #region UtilityFunctions
        public SudokuViewModel BuildViewModel()
        {
            var solution = _solutionFinder.GetPuzzle();

            SudokuViewModel svm = new SudokuViewModel()
            {
                PuzzlePiecesJsonObject = solution.PuzzlePiecesNumbers,
                PuzzlePieces = solution.PuzzlePiecesStrings
            }; ;
            return svm;
        }

        public SudokuViewModel BuildViewModel(string puzzleInput)
        {
            var solution = _solutionFinder.GetPuzzle(puzzleInput);

            SudokuViewModel svm = new SudokuViewModel()
            {
                PuzzlePiecesJsonObject = solution.PuzzlePiecesNumbers,
                PuzzlePieces = solution.PuzzlePiecesStrings
            }; ;
            return svm;
        }
        #endregion UtilityFunctions

    }
}
