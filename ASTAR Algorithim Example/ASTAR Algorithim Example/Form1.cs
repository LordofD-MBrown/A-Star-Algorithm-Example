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
//37:00
namespace ASTAR_Algorithim_Example{
    public partial class Form1 : Form{
        Button[,] grid;
        Cell[,] cells;
        Cell start = new Cell();
        Cell end = new Cell();        
        List<Cell> openSet = new List<Cell>();
        List<Cell> closedSet = new List<Cell>();
        List<Cell> path = new List<Cell>();
       
        public Form1(){
            InitializeComponent();
            grid = new Button[20, 10];
            cells = new Cell[20, 10];
            for(int i = 0; i < cells.GetLength(0); i++){
                for(int j = 0; j < cells.GetLength(1); j++){
                    cells[i, j] = new Cell(i,j);
                    cells[i, j].setText('0');
                    cells[i, j].setXValue(i);
                    cells[i, j].setYValue(j);
                }
            }
            for (int i = 0; i < cells.GetLength(0); i++){
                for( int j = 0; j < cells.GetLength(1); j++){
                    cells[i, j].addNeighbors(cells);
                }
            }
            createGrid();           
        }
        void createGrid(){
            for (int i = 0; i < grid.GetLength(0); i++){
                for (int j = 0; j < grid.GetLength(1); j++){
                    grid[i, j] = new Button();
                    grid[i, j].Text = cells[i,j].getText() + "";
                    grid[i, j].Tag = i + "," + j;
                    grid[i, j].Width = 600 / grid.GetLength(0);
                    grid[i, j].Height = 600 / grid.GetLength(1);
                    grid[i, j].Location = new Point(i * grid[i,j].Width, j * grid[i,j].Height);
                    grid[i, j].Click += Button_Click;
                    this.Controls.Add(grid[i, j]);
                }
            }
        }
        private void Button_Click(object sender, EventArgs e) {
            Button btn = sender as Button;
            string[] indexes = btn.Tag.ToString().Split(',');
            int x = Convert.ToInt32(indexes[0]);
            int y = Convert.ToInt32(indexes[1]);
            if (cells[x, y].getText() == '0') {
                cells[x, y].setText('W');
                grid[x, y].Text = cells[x, y].getText() + "";
                grid[x, y].BackColor = Color.Black;
            }
            else if (cells[x, y].getText() == 'W'){
                cells[x, y].setText('P');
                grid[x, y].Text = cells[x, y].getText() + "";
                grid[x, y].BackColor = Color.Empty;
            }
            else if (cells[x, y].getText() == 'P'){
                cells[x, y].setText('E');
                grid[x, y].Text = cells[x, y].getText() + "";
            }
            else if (cells[x, y].getText() == 'E'){
                cells[x, y].setText('0');
                grid[x, y].Text = cells[x, y].getText() + "";
            }
        }

        private void button1_Click(object sender, EventArgs e){
            AStarAlgorithim();
        }

        private void AStarAlgorithim(){
            //Set Starting and Ending points
            for (int i = 0; i < cells.GetLength(0); i++){
                for(int j = 0; j < cells.GetLength(1); j++){
                    if(cells[i,j].getText() == 'P'){
                        start = cells[i, j];
                    }
                    if(cells[i,j].getText() == 'E'){
                        end = cells[i, j];
                    }
                }
            }
            openSet.Add(start);
            Simulator.Enabled = true;
        }

        private void Simulator_Tick(object sender, EventArgs e)
        {
            //Modifiy the Color if it is in Open Set                 
            for (int i = 0; i < openSet.Count(); i++){
                int x = openSet[i].getXValue();
                int y = openSet[i].getYValue();
                grid[x, y].BackColor = Color.Purple;
            }
            //Modifiy the Color if it is in Closed Set   
            for (int i = 0; i < closedSet.Count(); i++){
                int x = closedSet[i].getXValue();
                int y = closedSet[i].getYValue();
                grid[x, y].BackColor = Color.DarkSlateBlue;
            }
            //Modifiy the coloe if it is in Path
            for (int i = 0; i < path.Count(); i++){
                int x = path[i].getXValue();
                int y = path[i].getYValue();
                grid[x, y].BackColor = Color.Green;
            }
            if(path.Count() > 0){
                Simulator.Enabled = false;
            }
            //Actual A Star=========================
            if (openSet != null){
                //F Value==========================================================
                int lowestIndex = 0;
                for (int i = 0; i < openSet.Count(); i++){
                    if(openSet[i].getFValue() < openSet[lowestIndex].getFValue()){
                        lowestIndex = i;
                    }
                }
                Cell current = new Cell();
                current = openSet[lowestIndex];
                if (openSet[lowestIndex].Equals(end)){
                    //Find path
                    Cell temp = new Cell();
                    temp = current;
                    path.Add(temp);
                    while(temp.getPrevious() != null){
                        path.Add(temp.getPrevious());
                        temp = temp.getPrevious();
                    }                  
                    Console.WriteLine("DONE");
                }
                //Refresh the open and closed set
                closedSet.Add(current);
                for(int i = 0; i < openSet.Count(); i++){
                    if (openSet[i] == current){
                        openSet.RemoveAt(i);
                    }
                }
                //get neighbors
                List<Cell> neighbors = new List<Cell>(current.getNeighbors());             
                for(int i = 0; i < neighbors.Count(); i++){
                    if (neighbors[i].getText() != 'W')
                    {
                        Console.WriteLine("=================");
                        Cell neighbor = neighbors[i];
                        bool found_1 = false;
                        for (int j = 0; j < closedSet.Count() && !found_1; j++)
                        {
                            if (closedSet[j] == neighbor)
                            {
                                found_1 = true;
                            }
                        }
                        if (!found_1)
                        {
                            //Adds one to the tentive g score or distance from start.
                            int tempG = neighbor.getGValue() + 1;
                            bool found_2 = false;
                            for (int j = 0; j < openSet.Count(); j++)
                            {
                                if (openSet[j] == neighbor)
                                {
                                    found_2 = true;
                                }
                            }
                            if (found_2)
                            {
                                if (tempG < neighbor.getGValue())
                                {
                                    neighbor.setGValue(tempG);
                                }
                            }
                            else if (!found_2)
                            {
                                neighbor.setGValue(tempG);
                                openSet.Add(neighbor);
                            }
                            neighbor.setHValue(heuristic(neighbor, end));
                            neighbor.setFValue(neighbor.getGValue() + neighbor.getHValue());
                            neighbor.setPrevious(current);
                        }
                    }
                }
            }
            else{
                //There is no path from P to E
            }
        }

        private double heuristic(Cell A, Cell B){
            //Distance Formula
            double x = (B.getXValue() - A.getXValue());
            double y = (B.getYValue() - A.getYValue());
            double distance = Math.Sqrt((x*x) + (y*y));
            return distance;
        }
    }  
}