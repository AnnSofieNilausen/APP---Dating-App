import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';  // Import HttpClientModule to enable HTTP services
import { FormsModule, ReactiveFormsModule } from '@angular/forms'; // Import FormsModule and ReactiveFormsModule for form handling

import { AppComponent } from './app.component';
import { ProfileComponent } from './profile/profile.component';
import { MatchingComponent } from './components/matching/matching.component'; // Ensure this path is correct
import { MutualMatchesComponent } from './components/mutual-matches/mutual-matches.component'; // Import the MutualMatchesComponent
import { LoginComponent } from './components/login/login.component'; // Import LoginComponent
import { ProfileService } from './services/profile.service'; // Ensure the path to your service is correct
import { MatchingService } from './services/matching.service'; // Ensure this path is correct
import { MatchesService } from './services/matches.service'; // Import the MatchesService
import { AuthService } from './services/auth.service'; // Import AuthService

@NgModule({
  declarations: [
    AppComponent,
    ProfileComponent, // Declare ProfileComponent to be part of this module
    MatchingComponent, // Declare MatchingComponent to be part of this module
    MutualMatchesComponent, // Declare MutualMatchesComponent to be part of this module
    LoginComponent  // Declare LoginComponent to be part of this module
  ],
  imports: [
    BrowserModule,
    HttpClientModule, // Include HttpClientModule to make it available throughout the app
    FormsModule,       // Include FormsModule for template-driven forms
    ReactiveFormsModule // Include ReactiveFormsModule for reactive forms
  ],
  providers: [
    ProfileService,  // Add ProfileService to the list of providers if not using providedIn: 'root'
    MatchingService, // Add MatchingService to the list of providers if not using providedIn: 'root'
    MatchesService,   // Add MatchesService to the list of providers if not using providedIn: 'root'
    AuthService       // Add AuthService to the list of providers if not using providedIn: 'root'
  ],
  bootstrap: [AppComponent] // Bootstrap the AppComponent as the root component
})
export class AppModule { }
