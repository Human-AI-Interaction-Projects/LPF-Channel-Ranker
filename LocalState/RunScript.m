% Wrapper script to run entire ML code process

% Reset all
clear all;
close all;
fclose all;

% Define directory paths and variables
mainDir = pwd;
ppath = 'C:\Users\timli\AppData\Local\Packages\16a2373a-1519-4dca-8c90-ac84a72b4cfd_kbtfgvzxh186t\LocalState';
featuresDir = fullfile(mainDir,'\ExtractedFeatures');
featuresDirOld = fullfile(mainDir,'\ExtractedFeaturesOld');
%signalsDir = fullfile(mainDir,'/Signals');
signalsDir = ppath;
headerFile = fullfile(signalsDir,'Header.txt');
numFile = 8;

% Define initial Signal dir file info
%signalFiles = fullfile(signalsDir,'*.txt');
signalFiles = fullfile(signalsDir,'Header.txt');
signalFileInfo = dir(signalFiles);

% Get most recent modification date
recentDate = signalFileInfo(1).datenum;
for n = 1:length(signalFileInfo)
    if signalFileInfo(n).datenum > recentDate
        recentDate = signalFileInfo(n).datenum;
    end
end

% Loop while checking modification date of Signal dir files
while true
    pause(0.2);
    % Check modification date of all Signal files
    signalFileInfo = dir(signalFiles);
    for n = 1:length(signalFileInfo)
        if signalFileInfo(n).datenum > recentDate
            
            % Update most recent mod date
            
            
            % Obtain test wave from Header file
            headerInfo = csvread(headerFile);
            testWave = headerInfo(1);
            weights = headerInfo(1,2:length(headerInfo)-1);
            if all(weights)
            % [5] Run entire ML code process
                RunML(testWave, headerFile, mainDir, featuresDir, featuresDirOld, signalsDir, numFile);
                disp('Wave Rank Updated');
            end
            % FOR TESTING
            % Plot test Wave in subplot
            enablet = 0;
            if enablet==1
                figure;
                wave = csvread(fullfile(signalsDir,sprintf('Wave%d.txt',testWave)));
                subplot(4,2,1);
                plot(wave);
                title(sprintf('Test Wave: Wave %d',testWave));

                % Plot ranked Waves in subplot
                waveRank = csvread('waveRank.txt');
                waveRank = waveRank+1;
                for rank = 1:(length(waveRank)-1)
                    waveNum = waveRank(rank);
                    wave = csvread(fullfile(signalsDir,sprintf('Wave%d.txt',waveNum)));
                    subplot(4,2,rank+1);
                    plot(wave);
                    title(sprintf('Rank %d: Wave %d',rank,waveNum));
                end
                drawnow;
            end
            
            recentDate = signalFileInfo(n).datenum;
        end
    end
end
