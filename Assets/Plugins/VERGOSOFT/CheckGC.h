//
//  CheckGC.h
//  CheckGC
//
//  Created by Scott Zastrow on 1/19/16.
//  Copyright © 2016 VERGOSOFT. All rights reserved.
//

#import <Foundation/Foundation.h>

@class GKPlayer;

@protocol GameCenterManagerDelegate <NSObject>

@property (nonatomic, assign)  id <GameCenterManagerDelegate> delegate;

@end
