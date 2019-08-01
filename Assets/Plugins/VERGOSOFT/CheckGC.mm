//
//  CheckGC.m
//  CheckGC
//
//  Created by Scott Zastrow on 1/19/16.
//  Copyright © 2016 VERGOSOFT. All rights reserved.
//

#import "CheckGC.h"

#import <GameKit/GameKit.h>

bool myBool;

extern "C"
{
    void checkStatus()
    {
        GKLocalPlayer *localPlayer = [GKLocalPlayer localPlayer];
        
        localPlayer.authenticateHandler = ^(UIViewController *viewController, NSError *error)
        {
            if (viewController == nil)
            {
                myBool = true;
                NSLog(@"User is signed in to GC. %d", myBool);
            }
            else
            {
                myBool = false;
                NSLog(@"User is NOT signed in to GC. %d", myBool);
            }
        };
    }
    bool getStatus(bool theBool)
    {
        theBool = myBool;
        NSLog(@"theBool result is: %d and myBool result is: %d", theBool, myBool);
        return theBool;
    }
    
}
