/*
Simple Rock Paper Scissors Program

*/
#include <iostream>
#include <time.h>
#include <string>
#include <bits/stdc++.h>

using namespace std;
string choice; // Player Choice
string tool; // CPU Choice

string PlayerChoice(){
    cout << "Choose: Rock, Paper, or Scissors \n";
    cin >> choice;
    
    transform(choice.begin(), choice.end(), choice.begin(), ::tolower); // Makes string all lowercase
    if(( choice == "rock") || (choice == "paper") || (choice == "scissors")){
        return choice;
    }else{
        cout << "Please choose a valid input \n";
        PlayerChoice(); //calls function again until one of the three is entered
    }

    return choice;

}

string OpponentSelection(){

    int CPU_Choice = rand() %3; // uses srand to randomly make a Computer choice
    
    switch (CPU_Choice)
    {
    case 0:
    tool = "rock";
    return tool;

    case 1:
    tool = "paper";
    return tool;

    case 2:
    tool = "scissors";
    return tool;

    default:
        break;
    }
    return tool;
}
string Versus(string choice, string tool){
cout <<"\n" << "You chose: " << choice << "\nYour Opponent chose: " << tool << "\n";
//int choice_INT, tool_INT;

    if(choice == tool){
        cout << "Both players chose " << tool << " Go again!\n";
    return Versus(PlayerChoice(), OpponentSelection());
    }

    if( choice == "rock"){
        if(tool == "paper"){
            cout << "You lose!\n";
        } else
        {
            if(tool == "scissors"){
                cout << "You win!\n";
            }
        }
        
    }

    if( choice == "paper"){
        if(tool == "scissors"){
            cout << "You lose!\n";
        } else{
            if(tool == "rock"){
                cout << "You win!\n";
            }
        }
        
    }

    if( choice == "scissors"){
        if(tool == "rock"){
            cout << "You lose!\n";
        } else {
            if(tool == "paper"){
                cout << "You win!\n";
            }
        }
        
    }

    return 0;
}
int main(){
    srand (time(NULL));
    
    PlayerChoice();
    Versus(choice, OpponentSelection());
    return 0;
}
