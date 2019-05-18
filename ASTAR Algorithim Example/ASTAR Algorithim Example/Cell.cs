using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ASTAR_Algorithim_Example
{
    class Cell
    {
        int gValue;
        double hValue;
        double fValue;
        int xValue;
        int yValue;
        char text;
        List<Cell> neighbors = new List<Cell>();
        Cell previous;

        //Constructors=========================
        public Cell(){

        }
        public Cell(int t_x, int t_y){
            xValue = t_x;
            yValue = t_y;
        }
        //Setters==============================
        public void setGValue(int t_gValue){
            gValue = t_gValue;
        }
        public void setHValue(double t_hValue){
            hValue = t_hValue;
        }
        public void setFValue(double t_fValue){
            fValue = t_fValue;
        }
        public void setXValue(int t_xValue){
            xValue = t_xValue;
        }
        public void setYValue(int t_yValue){
            yValue = t_yValue;
        }
        public void setText(char t_text){
            text = t_text;
        }     
        public void setNeighbors(List<Cell> t_neighbors){
            neighbors = t_neighbors;
        }
        public void setPrevious(Cell t_prev){
            previous = new Cell();
            previous = t_prev;
        }
        //Getters==========================
        public int getGValue(){
            return gValue;
        }
        public double getHValue(){
            return hValue;
        }
        public double getFValue(){
            return fValue;
        }
        public int getXValue(){
            return xValue;
        }
        public int getYValue(){
            return yValue;
        }
        public char getText(){
            return text;
        }
        public List<Cell> getNeighbors(){          
            return neighbors;
        }
        public Cell getPrevious(){
            return previous;
        }
        //Other Functions===========================
        public void addNeighbors(Cell[,] grid){
            //Left
            if (xValue < (grid.GetLength(0) - 1)){
                neighbors.Add(grid[xValue + 1, yValue]);
                //Console.WriteLine("grid " + (xValue+1) + ", " + yValue);
            }
            //Upper Left
            //if (xValue > 0 && yValue > 0){
            //    neighbors.Add(grid[xValue - 1, yValue - 1]);
            //}
            //Downer Left
            //if (xValue > 0 && yValue < (grid.GetLength(1) - 1)){
            //    neighbors.Add(grid[xValue - 1, yValue + 1]);
            //}          
            //Right
            if (xValue > 0){
                neighbors.Add(grid[xValue - 1, yValue]);
                //Console.WriteLine("grid " + (xValue-1) + ", " + yValue);
            }
            //Upper Right
            //if (xValue < (grid.GetLength(0) - 1) && yValue > 0){
            //    neighbors.Add(grid[xValue + 1, yValue - 1]);
            //}
            //Downer Right
            //if (xValue < (grid.GetLength(0) - 1) && yValue < (grid.GetLength(1) - 1)){
            //    neighbors.Add(grid[xValue + 1, yValue + 1]);
            //}
            //Down
            if (yValue < (grid.GetLength(1)-1)){
                neighbors.Add(grid[xValue, yValue + 1]);
                //Console.WriteLine("grid " + xValue + ", " + (yValue + 1));
            }
            //Top
            if(yValue > 0){
                neighbors.Add(grid[xValue, yValue - 1]);
                //Console.WriteLine("grid " + xValue + ", " + (yValue - 1));
            }

            Console.WriteLine("=================");
            for (int i = 0; i < neighbors.Count(); i++){               
                Console.WriteLine("grid " + neighbors[i].getXValue() + ", " + neighbors[i].getYValue());
            }
        }

        public void removeNeighbors(Cell neighbor){
            neighbors.Remove(neighbor);
        }
    }
}
